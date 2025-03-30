using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using BitePaper.Infrastructure.Interfaces.Auth;
using BitePaper.Infrastructure.Settings;
using BitePaper.Models.DTOs.Request.Auth;
using BitePaper.Models.DTOs.Response.Auth;
using BitePaper.Models.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;

namespace BitePaper.Infrastructure.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IMongoCollection<User> _collection;
    private readonly IMongoCollection<RefreshToken> _refreshTokenCollection;
    private readonly IConfiguration _configuration;
    private readonly ILogger<AuthService> _logger;
    private readonly JwtSettings _jwtSettings;

    public AuthService(
        IConfiguration configuration,
        ILogger<AuthService> logger,
        IOptions<JwtSettings> jwtSettings)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _logger = logger;
        _jwtSettings = jwtSettings.Value;

        var connectionString = _configuration["MongoDB:ConnectionString"];
        var databaseName = _configuration["MongoDB:DatabaseName"];

        if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(databaseName))
        {
            _logger.LogError("MongoDB configuration is missing.");
            throw new InvalidOperationException("MongoDB configuration is invalid.");
        }

        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        _collection = database.GetCollection<User>("Users");
        _refreshTokenCollection = database.GetCollection<RefreshToken>("RefreshTokens");
    }

    public async Task<AuthResponseDto?> LoginAsync(LoginDto request)
    {
        var user = await _collection.Find(u => u.Email == request.Email).FirstOrDefaultAsync();
        if (user is null)
        {
            _logger.LogWarning("Login failed: User not found.");
            return null;
        }

        var passwordHasher = new PasswordHasher<User>();
        var verificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);

        if (verificationResult == PasswordVerificationResult.Failed)
        {
            _logger.LogWarning("Login failed: Invalid credentials.");
            return null;
        }

        _logger.LogInformation("User {Email} logged in successfully.", user.Email);
        return await GenerateAuthResponseAsync(user);
    }

    public async Task<AuthResponseDto?> RegisterAsync(RegisterDto request)
    {
        if (await _collection.Find(u => u.Email == request.Email).AnyAsync())
        {
            _logger.LogWarning("Registration failed: Email already exists.");
            return null;
        }

        var user = await CreateUser(request);
        if (user is null)
        {
            _logger.LogError("Registration failed: Unable to create user.");
            return null;
        }

        try
        {
            await _collection.InsertOneAsync(user);
            _logger.LogInformation("User {Email} registered successfully.", user.Email);
            return await GenerateAuthResponseAsync(user);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error saving user to the database.");
            return null;
        }
    }

    public async Task<AuthResponseDto?> RefreshTokenAsync(string refreshToken)
    {
        var storedToken = await _refreshTokenCollection
            .Find(t => t.Token == refreshToken && t.IsRevoked == false)
            .FirstOrDefaultAsync();

        if (storedToken == null || storedToken.ExpiresAt < DateTime.UtcNow)
        {
            return null;
        }

        var user = await _collection.Find(u => u.Id == storedToken.UserId).FirstOrDefaultAsync();
        if (user == null)
        {
            return null;
        }

        // Оновлюємо існуючий токен
        var newToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        var update = Builders<RefreshToken>.Update
            .Set(t => t.Token, newToken)
            .Set(t => t.ExpiresAt, DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpirationInDays));

        await _refreshTokenCollection.UpdateOneAsync(
            t => t.Id == storedToken.Id,
            update);

        return new AuthResponseDto
        {
            AccessToken = CreateAccessToken(user),
            RefreshToken = newToken
        };
    }

    public async Task RevokeTokenAsync(string refreshToken)
    {
        var update = Builders<RefreshToken>.Update.Set(t => t.IsRevoked, true);
        await _refreshTokenCollection.UpdateOneAsync(
            t => t.Token == refreshToken && t.IsRevoked == false,
            update);
    }

    private async Task<AuthResponseDto> GenerateAuthResponseAsync(User user)
    {
        var accessToken = CreateAccessToken(user);
        var refreshToken = await GetOrCreateRefreshTokenAsync(user);

        return new AuthResponseDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken.Token
        };
    }

    private string CreateAccessToken(User user)
    {
        if (string.IsNullOrEmpty(_jwtSettings.Secret))
        {
            throw new InvalidOperationException("JWT Secret is not configured.");
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Role, user.Role?.Name ?? "User")
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
        var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationInMinutes),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }

    private async Task<RefreshToken> GetOrCreateRefreshTokenAsync(User user)
    {
        // Шукаємо активний токен користувача
        var existingToken = await _refreshTokenCollection
            .Find(t => t.UserId == user.Id && t.IsRevoked == false)
            .FirstOrDefaultAsync();

        if (existingToken != null)
        {
            // Оновлюємо існуючий токен
            var newToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            var update = Builders<RefreshToken>.Update
                .Set(t => t.Token, newToken)
                .Set(t => t.ExpiresAt, DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpirationInDays));

            await _refreshTokenCollection.UpdateOneAsync(
                t => t.Id == existingToken.Id,
                update);

            existingToken.Token = newToken;
            existingToken.ExpiresAt = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpirationInDays);
            return existingToken;
        }

        // Створюємо новий токен тільки якщо немає жодного токена для користувача
        var newRefreshToken = new RefreshToken
        {
            Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
            UserId = user.Id,
            ExpiresAt = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpirationInDays),
            IsRevoked = false
        };

        await _refreshTokenCollection.InsertOneAsync(newRefreshToken);
        return newRefreshToken;
    }

    private async Task<User?> CreateUser(RegisterDto request)
    {
        var user = new User
        {
            Email = request.Email,
            Role = request.Role,
            FullName = request.FullName,
            DateOfBirth = request.DateOfBirth,
            GoogleId = request.GoogleId ?? string.Empty,
            PictureUrl = request.PictureUrl,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        user.PasswordHash = new PasswordHasher<User>().HashPassword(user, request.Password);
        return user;
    }
}
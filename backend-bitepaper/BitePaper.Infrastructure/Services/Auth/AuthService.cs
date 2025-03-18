using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BitePaper.Infrastructure.Interfaces.Auth;
using BitePaper.Models.DTOs.Request.Auth;
using BitePaper.Models.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;

namespace BitePaper.Infrastructure.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IMongoCollection<User> _collection;
    private readonly IConfiguration _configuration;
    private readonly ILogger<AuthService> _logger;

    public AuthService(IConfiguration configuration, ILogger<AuthService> logger)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _logger = logger;

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
    }

    #region Login

    public async Task<string?> LoginAsync(LoginDto request)
    {
        var user = await _collection.Find(u => u.Email == request.Email).FirstOrDefaultAsync();
        if (user is null)
        {
            _logger.LogWarning("Login failed: User not found.");
            return "User not found";
        }

        var passwordHasher = new PasswordHasher<User>();
        var verificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);

        if (verificationResult == PasswordVerificationResult.Failed)
        {
            _logger.LogWarning("Login failed: Invalid credentials.");
            return "Invalid password or email";
        }

        _logger.LogInformation("User {Email} logged in successfully.", user.Email);
        return CreateToken(user);
    }

    #endregion

    #region Register

    public async Task<string?> RegisterAsync(RegisterDto request)
    {
        if (await _collection.Find(u => u.Email == request.Email).AnyAsync())
        {
            _logger.LogWarning("Registration failed: Email already exists.");
            return "Email already exists";
        }

        var user = await CreateUser(request);
        if (user is null)
        {
            _logger.LogError("Registration failed: Unable to create user.");
            return "User creation failed";
        }

        try
        {
            await _collection.InsertOneAsync(user);
            _logger.LogInformation("User {Email} registered successfully.", user.Email);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error saving user to the database.");
            return "Error saving user to the database!";
        }

        return "Registration successful!";
    }

    #endregion

    private string CreateToken(User user)
    {
        var key = _configuration["JWT:Secret"];
        var issuer = _configuration["JWT:Issuer"];
        var audience = _configuration["JWT:Audience"];

        if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(issuer) || string.IsNullOrEmpty(audience))
        {
            _logger.LogError("JWT configuration is missing.");
            throw new InvalidOperationException("JWT configuration is invalid.");
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Role, user.Role?.Name ?? "User")
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }

    private async Task<User?> CreateUser(RegisterDto request)
    {
        var user = new User
        {
            Email = request.Email,
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
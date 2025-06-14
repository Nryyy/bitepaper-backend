using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using BitePaper.Application.Handlers.Departments;
using BitePaper.Infrastructure.Interfaces.Departments;
using BitePaper.Infrastructure.Repositories.Departments;
using BitePaper.Infrastructure.Services.Departments;

using BitePaper.Application.Handlers.Documents;
using BitePaper.Infrastructure.Interfaces.Documents;
using BitePaper.Infrastructure.Repositories.Documents;
using BitePaper.Infrastructure.Services.Documents;

using BitePaper.Application.Handlers.Roles;
using BitePaper.Infrastructure.Interfaces.Roles;
using BitePaper.Infrastructure.Repositories.Roles;
using BitePaper.Infrastructure.Services.Roles;

using BitePaper.Application.Handlers.Users;
using BitePaper.Infrastructure.Interfaces.Users;
using BitePaper.Infrastructure.Repositories.Users;
using BitePaper.Infrastructure.Services.Users;

using BitePaper.Application.Handlers.Statuses;
using BitePaper.Infrastructure.Interfaces.Statuses;
using BitePaper.Infrastructure.Services.Statuses;
using BitePaper.Infrastructure.Repositories.Statuses;

using BitePaper.Application.Handlers.DocumentComments;
using BitePaper.Infrastructure.Interfaces.DocumentComments;
using BitePaper.Infrastructure.Repositories.DocumentComments;
using BitePaper.Infrastructure.Services.DocumentComments;

using BitePaper.Infrastructure.Interfaces.Auth;
using BitePaper.Infrastructure.Services.Auth;

using BitePaper.Infrastructure.Interfaces.Signatures;
using BitePaper.Infrastructure.Repositories.Signatures;
using BitePaper.Infrastructure.Services.Signatures;
using BitePaper.Application.Handlers.Signatures;

using BitePaper.Infrastructure.Interfaces.Logs;
using BitePaper.Infrastructure.Repositories.Logs;
using BitePaper.Infrastructure.Services.Logs;
using BitePaper.Application.Handlers.Logs;

using BitePaper.Infrastructure.Interfaces.Steps;
using BitePaper.Infrastructure.Repositories.Steps;
using BitePaper.Infrastructure.Services.Steps;
using BitePaper.Application.Handlers.Steps;

using BitePaper.Infrastructure.Interfaces.ApprovalFlows;
using BitePaper.Infrastructure.Repositories.ApprovalFlows;
using BitePaper.Infrastructure.Services.ApprovalFlows;
using BitePaper.Application.Handlers.ApprovalFlows;

using BitePaper.Infrastructure.Interfaces.Notifications;
using BitePaper.Infrastructure.Repositories.Notifications;
using BitePaper.Infrastructure.Services.Notifications;
using BitePaper.Application.Handlers.Notifications;

using BitePaper.Infrastructure.Settings;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Logger
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Configure JWT Settings
builder.Services.Configure<JwtSettings>(configuration.GetSection("JWT"));

// Authorization & Authentication
builder.Services.AddAuthorization();
ConfigureAuthentication(builder.Services, configuration);

// Register Repositories and Services
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();

builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddScoped<IDocumentService, DocumentService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddScoped<IStatusService, StatusService>();

builder.Services.AddScoped<ILogRepository, LogRepository>();
builder.Services.AddScoped<ILogService, LogService>();

builder.Services.AddScoped<ISignatureRepository, SignatureRepository>();
builder.Services.AddScoped<ISignatureService, SignatureService>();

builder.Services.AddScoped<IDocumentCommentRepository, DocumentCommentRepository>();
builder.Services.AddScoped<IDocumentCommentService, DocumentCommentService>();

builder.Services.AddScoped<IStepRepository, StepRepository>();
builder.Services.AddScoped<IStepService, StepService>();

builder.Services.AddScoped<IApprovalFlowRepository, ApprovalFlowRepository>();
builder.Services.AddScoped<IApprovalFlowService, ApprovalFlowService>();

builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<INotificationService, NotificationService>();

// CORS Configuration - Allow Everything
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// Register MediatR Handlers
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(CreateDepartmentHandler).Assembly);
    config.RegisterServicesFromAssembly(typeof(CreateRoleHandler).Assembly);
    config.RegisterServicesFromAssembly(typeof(CreateDocumentHandler).Assembly);
    config.RegisterServicesFromAssembly(typeof(CreateUserHandler).Assembly);
    config.RegisterServicesFromAssembly(typeof(CreateStatusHandler).Assembly);
    config.RegisterServicesFromAssembly(typeof(CreateLogHandler).Assembly);
    config.RegisterServicesFromAssembly(typeof(CreateSignatureHandler).Assembly);
    config.RegisterServicesFromAssembly(typeof(CreateDocumentCommentHandler).Assembly);
    config.RegisterServicesFromAssembly(typeof(CreateStepHandler).Assembly);
    config.RegisterServicesFromAssembly(typeof(CreateApprovalFlowHandler).Assembly);
    config.RegisterServicesFromAssembly(typeof(CreateNotificationHandler).Assembly);
});

// Register FastEndpoints & Swagger
builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument();

var app = builder.Build();

// Logger startup message
var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Starting application...");

// Swagger for Development
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerGen();
}

// Enable CORS
app.UseCors("AllowAll");

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints();

app.Run();

void ConfigureAuthentication(IServiceCollection services, IConfiguration config)
{
    var jwtKey = config["JWT:Secret"];
    if (string.IsNullOrEmpty(jwtKey))
    {
        throw new InvalidOperationException("JWT Secret is missing in configuration.");
    }

    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));

    services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddCookie()
    .AddGoogle(options =>
    {
        options.ClientId = config["Authentication:Google:ClientId"] ?? throw new InvalidOperationException();
        options.ClientSecret = config["Authentication:Google:ClientSecret"] ?? throw new InvalidOperationException();
        options.CallbackPath = "/auth/google-callback";
    })
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = true;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key,
            ValidateIssuer = true,
            ValidIssuer = config["JWT:Issuer"],
            ValidateAudience = true,
            ValidAudience = config["JWT:Audience"],
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });
}
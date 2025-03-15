using BitePaper.Application.Handlers.Departments;
using BitePaper.Application.Handlers.Documents;
using BitePaper.Application.Handlers.Roles;
using BitePaper.Infrastructure.Interfaces.Departments;
using BitePaper.Infrastructure.Interfaces.Documents;
using BitePaper.Infrastructure.Interfaces.Roles;
using BitePaper.Infrastructure.Repositories.Departments;
using BitePaper.Infrastructure.Repositories.Documents;
using BitePaper.Infrastructure.Repositories.Roles;
using BitePaper.Infrastructure.Services.Departments;
using BitePaper.Infrastructure.Services.Documents;
using BitePaper.Infrastructure.Services.Roles;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;

var builder = WebApplication.CreateBuilder(args);

// Register Authorization and Authentication Services
builder.Services.AddAuthorization();

// Add FastEndpoints and Swagger
builder.Services.AddFastEndpoints()
    .SwaggerDocument()
    .AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
    })
    .AddCookie()
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
        options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
        options.CallbackPath = "/auth/google-callback";
    });

// Register Repositories and Services
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();

builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddScoped<IDocumentService, DocumentService>();

// Register MediatR Handlers
builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(CreateDepartmentHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(CreateRoleHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(CreateDocumentHandler).Assembly);
});

var app = builder.Build();

// Swagger for Development
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerGen(); // Generate Swagger documentation in development environment
}

app.UseHttpsRedirection();
app.UseFastEndpoints();
app.UseAuthentication();
app.UseAuthorization();

app.Run();

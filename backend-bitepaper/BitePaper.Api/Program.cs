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

var builder = WebApplication.CreateBuilder(args);

// Registering FastEndpoints with Swagger
builder.Services.AddFastEndpoints()
    .SwaggerDocument();

// Registering dependencies
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();

builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddScoped<IDocumentService, DocumentService>();

// Setting up MediatR
builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(CreateDepartmentHandler).Assembly);
    
    configuration.RegisterServicesFromAssembly(typeof(CreateRoleHandler).Assembly);
    
    configuration.RegisterServicesFromAssembly(typeof(CreateDocumentHandler).Assembly);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerGen(); // Generation of Swagger documentation
}

app.UseHttpsRedirection();
app.UseFastEndpoints();

app.Run();

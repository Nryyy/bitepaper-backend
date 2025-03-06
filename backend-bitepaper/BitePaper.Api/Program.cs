using BitePaper.Application.Handlers.Departments;
using BitePaper.Application.Handlers.Roles;
using BitePaper.Infrastructure.Interfaces.Departments;
using BitePaper.Infrastructure.Interfaces.Roles;
using BitePaper.Infrastructure.Repositories.Departments;
using BitePaper.Infrastructure.Repositories.Roles;
using BitePaper.Infrastructure.Services.Departments;
using BitePaper.Infrastructure.Services.Roles;
using FastEndpoints;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddFastEndpoints();

builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(CreateDepartmentHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(UpdateDepartmentHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(DeleteDepartmentHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(GetAllDepartmentHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(GetDepartmentByIdHandler).Assembly);
    
    configuration.RegisterServicesFromAssembly(typeof(CreateRoleCommandHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(DeleteRoleCommandHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(GetAllRoleCommandHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(GetByIdRoleCommandHandler).Assembly);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseFastEndpoints();

app.Run();
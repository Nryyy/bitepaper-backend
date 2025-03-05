using BitePaper.Application.Handlers.Departments;
using BitePaper.Infrastructure.Interfaces.Departments;
using FastEndpoints;
using BitePaper.Infrastructure.Repositories.Departments;
using BitePaper.Infrastructure.Services.Departments;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFastEndpoints();

builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(CreateDepartmentHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(UpdateDepartmentHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(DeleteDepartmentHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(GetAllDepartmentHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(GetDepartmentByIdHandler).Assembly);
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
using BitePaper.Application.Handlers.TestEnteties;
using FastEndpoints;
using BitePaper.Infrastructure.Interfaces.TestEntities;
using BitePaper.Infrastructure.Repositories.TestEnteties;
using BitePaper.Infrastructure.Services.TestEnteties;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ITestRepository, TestRepository>();
builder.Services.AddSingleton<ITestService, TestService>();

builder.Services.AddMediatR(configuration =>
    configuration.RegisterServicesFromAssembly(typeof(CreateTestEntetyCommandHandler).Assembly));

builder.Services.AddFastEndpoints();

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
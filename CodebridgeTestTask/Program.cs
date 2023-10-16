using Application;
using Application.Common.Interfaces;
using AspNetCoreRateLimit;
using Carter;
using Infrastructure;
using WebApi.Middlewares;
using WebApi.Misc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddApplication();

var connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddInfrastructure(connectionString!);

builder.Services.AddCarter();

var rateLimitingOptions = builder.Configuration.GetSection("IpRateLimiting");

builder.Services.AddMemoryCache();

builder.Services.Configure<IpRateLimitOptions>(rateLimitingOptions);

builder.Services.AddInMemoryRateLimiting();

builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseIpRateLimiting();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    using (var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>())
    {
        await unitOfWork.SeedData();
    }
}

app.UseHttpsRedirection();

app.MapCarter();

app.Run();
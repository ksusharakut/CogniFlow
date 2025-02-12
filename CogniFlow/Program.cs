using CogniFlow.Data;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

DotNetEnv.Env.Load();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(
        $"Host={Environment.GetEnvironmentVariable("DATABASE_HOST")};" +
        $"Port={Environment.GetEnvironmentVariable("DATABASE_PORT")};" +
        $"Database={Environment.GetEnvironmentVariable("DATABASE_NAME")};" +
        $"Username={Environment.GetEnvironmentVariable("DATABASE_USERNAME")};" +
        $"Password={Environment.GetEnvironmentVariable("DATABASE_PASSWORD")}"));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

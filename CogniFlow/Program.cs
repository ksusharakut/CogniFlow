using CogniFlow.Data;
using CogniFlow.Repositories.Interfaces;
using CogniFlow.Repositories;
using CogniFlow.Services.Interfaces;
using CogniFlow.Services;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using CogniFlow.Mappings;
using CogniFlow.Utilities.Interfaces;
using CogniFlow.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(UserProfile));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPasswordHandler, PasswordHandler>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

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

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();

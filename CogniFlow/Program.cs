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
using CogniFlow;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();
services.AddAutoMapperProfiles();
services.AddRepositories();
services.AddServices();
services.AddUtilities();

DotNetEnv.Env.Load();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(
        $"Host={Environment.GetEnvironmentVariable("DATABASE_HOST")};" +
        $"Port={Environment.GetEnvironmentVariable("DATABASE_PORT")};" +
        $"Database={Environment.GetEnvironmentVariable("DATABASE_NAME")};" +
        $"Username={Environment.GetEnvironmentVariable("DATABASE_USERNAME")};" +
        $"Password={Environment.GetEnvironmentVariable("DATABASE_PASSWORD")}"));

var app = builder.Build();


app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();

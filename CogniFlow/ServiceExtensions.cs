using CogniFlow.Mappings;
using CogniFlow.Repositories;
using CogniFlow.Repositories.Interfaces;
using CogniFlow.Services.Interfaces;
using CogniFlow.Services;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Identity;
using CogniFlow.Utilities.Interfaces;
using CogniFlow.Utilities;

namespace CogniFlow
{
    public static class ServiceExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
        }

        public static void AddAutoMapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserProfile).Assembly);
            services.AddAutoMapper(typeof(RoleProfile).Assembly);
        }

        public static void AddUtilities(this IServiceCollection services)
        {
            services.AddScoped<IPasswordUtility, PasswordUtility>();
        }
    }
}

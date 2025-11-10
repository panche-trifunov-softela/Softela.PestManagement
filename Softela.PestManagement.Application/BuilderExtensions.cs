using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Softela.PestManagement.Application.Core.Command;
using Softela.PestManagement.Application.Core.Query;
using Softela.PestManagement.Application.Services.AuthToken;
using Softela.PestManagement.Domain.Entities;
using System.Reflection;

namespace Softela.PestManagement.Application
{
    public static partial class BuilderExtensions
    {
        private static Assembly ApplicationAssembly => typeof(BuilderExtensions).Assembly;

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(ApplicationAssembly))
                .AddScoped<ICommandDispatcher, CommandDispatcher>()
                .AddScoped<IQueryDispatcher, QueryDispatcher>();

            services.AddScoped<IAuthToken, AuthToken>();

            // Register IPasswordHasher<User> with PasswordHasher<User> as the implementation
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

            return services;
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Softela.PestManagement.Application.Core.Command;
using Softela.PestManagement.Application.Core.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

            return services;
        }
    }
}

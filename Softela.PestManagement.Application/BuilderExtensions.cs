using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Softela.PestManagement.Application.Core.Command;
using Softela.PestManagement.Application.Core.Query;
using Softela.PestManagement.Application.Outbox;
using System.Reflection;

namespace Softela.PestManagement.Application
{
    public static partial class BuilderExtensions
    {
        private static Assembly ApplicationAssembly => typeof(BuilderExtensions).Assembly;

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(ApplicationAssembly))
                .AddScoped<ICommandDispatcher, CommandDispatcher>()
                .AddScoped<IQueryDispatcher, QueryDispatcher>();

            // TODO: Temporary — remove once real per-event handlers are in place.
            if (!environment.IsProduction())
                services.AddTransient(typeof(INotificationHandler<>), typeof(DomainEventLoggingHandler<>));

            services.Configure<OutboxOptions>(configuration.GetSection(OutboxOptions.SectionName));
            services.AddHostedService<OutboxProcessorJob>();

            return services;
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Softela.PestManagement.Application.Repositories;
using Softela.PestManagement.Infrastructure.Database.Connections;
using Softela.PestManagement.Infrastructure.Database.Dapper;
using Softela.PestManagement.Infrastructure.Database.Migrator;
using Softela.PestManagement.Infrastructure.Database.Repositories;

namespace Softela.PestManagement.Infrastructure
{
    public static partial class BuilderExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = new DatabaseConnectionStringProvider(configuration).GetConnectionString();

            services
                .AddScoped<IDapperDataContext, DapperDataContext>()
                .AddScoped<IDatabaseConnection, DatabaseConnection>()
                .AddScoped<IDbMigrator, DbMigrator>();

            services.AddHealthChecks()
                .AddSqlServer(connectionString, name: "sqlserver");

            services.AddScoped<ISiteRepository, SiteRepository>();

            var serviceProviderFactory = new DefaultServiceProviderFactory();
            var serviceProvider = serviceProviderFactory.CreateServiceProvider(services);
            var dbMigrator = serviceProvider.GetRequiredService<IDbMigrator>();
            dbMigrator.Migrate();

            return services;
        }
    }
}

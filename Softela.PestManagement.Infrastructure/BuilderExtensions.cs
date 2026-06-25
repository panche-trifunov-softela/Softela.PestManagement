using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Softela.PestManagement.Application.Core.FeatureFlags;
using Softela.PestManagement.Application.Repositories;
using Softela.PestManagement.Infrastructure.Core.FeatureFlags;
using Softela.PestManagement.Infrastructure.Database;
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
            DefaultTypeMap.MatchNamesWithUnderscores = true;

            var connectionString = new DatabaseConnectionStringProvider(configuration).GetConnectionString();

            services
                .AddScoped<IDapperDataContext, DapperDataContext>()
                .AddScoped<IDatabaseConnection, DatabaseConnection>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IDbMigrator, DbMigrator>();

            services.AddHealthChecks()
                .AddNpgSql(connectionString, name: "postgresql");

            services.AddScoped<ITenantRepository, TenantRepository>();
            services.AddScoped<ITenantFeatureRepository, TenantFeatureRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerContactRepository, CustomerContactRepository>();
            services.AddScoped<IServiceAddressRepository, ServiceAddressRepository>();
            services.AddScoped<IEstimateRepository, EstimateRepository>();
            services.AddScoped<IProgramRepository, ProgramRepository>();
            services.AddScoped<ICfgEstimateRepository, CfgEstimateRepository>();
            services.AddScoped<ICfgProgramRepository, CfgProgramRepository>();
            services.AddScoped<ICfgEventRepository, CfgEventRepository>();
            services.AddScoped<ICfgCadenceRepository, CfgCadenceRepository>();
            services.AddScoped<ICfgProgramEventCadenceRepository, CfgProgramEventCadenceRepository>();
            services.AddScoped<IOutboxRepository, OutboxRepository>();
            services.AddScoped<IFeatureFlagService, FeatureFlagService>();

            var serviceProviderFactory = new DefaultServiceProviderFactory();
            var serviceProvider = serviceProviderFactory.CreateServiceProvider(services);
            var dbMigrator = serviceProvider.GetRequiredService<IDbMigrator>();
            dbMigrator.Migrate();

            return services;
        }
    }
}

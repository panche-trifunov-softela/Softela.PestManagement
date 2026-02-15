using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Softela.PestManagement.Application.Repositories;
using Softela.PestManagement.Infrastructure.Database.Connections;
using Softela.PestManagement.Infrastructure.Database.Dapper;
using Softela.PestManagement.Infrastructure.Database.Migrator;
using Softela.PestManagement.Infrastructure.Database.Repositories;
using Microsoft.AspNetCore.Identity;
using Softela.PestManagement.Domain.Entities;
using Softela.PestManagement.Infrastructure.Identity;

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
                .AddSqlServer(connectionString, "sqlserver");

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ISiteRepository, SiteRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUserStore<User>, UserStore>();
            services.AddScoped<IRoleStore<Role>, RoleStore>();

            var serviceProviderFactory = new DefaultServiceProviderFactory();
            var serviceProvider = serviceProviderFactory.CreateServiceProvider(services);
            var dbMigrator = serviceProvider.GetRequiredService<IDbMigrator>();
            dbMigrator.Migrate();

            return services;
        }
    }
}

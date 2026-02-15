using Microsoft.Extensions.Configuration;

namespace Softela.PestManagement.Infrastructure.Database.Connections
{
    public class DatabaseConnectionStringProvider
    {
        private readonly IConfiguration _configuration;

        public DatabaseConnectionStringProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("pestmanagement")
                ?? throw new InvalidOperationException("Connection string 'pestmanagement' not found.");
        }
    }
}

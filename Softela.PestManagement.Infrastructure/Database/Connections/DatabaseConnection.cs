using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace Softela.PestManagement.Infrastructure.Database.Connections
{
    public class DatabaseConnection : DatabaseConnectionStringProvider, IDatabaseConnection
    {
        public DatabaseConnection(IConfiguration configuration) : base(configuration)
        { }

        public IDbConnection GetConnection() => new NpgsqlConnection(GetConnectionString());
    }
}

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Softela.PestManagement.Infrastructure.Database.Connections
{
    public class DatabaseConnection : DatabaseConnectionStringProvider, IDatabaseConnection
    {
        public DatabaseConnection(IConfiguration configuration) : base(configuration)
        { }

        public IDbConnection GetConnection() => new SqlConnection(GetConnectionString());
    }
}

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Softela.PestManagement.Application.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softela.PestManagement.Infrastructure.Database.Connections
{
    public class DatabaseConnection : DatabaseConnectionStringProvider, IDatabaseConnection
    {
        public DatabaseConnection(DatabaseOptions dbOptions, IConfiguration configuration) : base(dbOptions, configuration)
        { }

        public IDbConnection GetConnection() => new SqlConnection(GetConnectionString());
    }
}

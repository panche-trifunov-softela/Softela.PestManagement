using EvolveDb;
using Npgsql;
using Softela.PestManagement.Infrastructure.Database.Connections;
using System.Data.Common;
using System.Reflection;

namespace Softela.PestManagement.Infrastructure.Database.Migrator
{
    public class DbMigrator : IDbMigrator
    {
        private readonly IDatabaseConnection _databaseConnection;

        public DbMigrator(IDatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public void Migrate()
        {
            EnsureDatabaseExists();

            var paths = new string[] { "Database", "Scripts" };
            var executingAssemblyLocation = Assembly.GetExecutingAssembly().Location;
            var executingAssemblyLocationPath = Path.GetDirectoryName(executingAssemblyLocation);
            if (!string.IsNullOrWhiteSpace(executingAssemblyLocationPath))
            {
                paths = paths.Prepend(executingAssemblyLocationPath).ToArray();
            }

            using var connection = _databaseConnection.GetConnection();
            var scriptsLocation = Path.Combine(paths.ToArray());
            var evolve = new Evolve((DbConnection)connection)
            {
                IsEraseDisabled = true,
                CommandTimeout = 600,
                Locations = new[] { scriptsLocation }
            };
            evolve.Migrate();
        }

        private void EnsureDatabaseExists()
        {
            var connectionString = _databaseConnection.GetConnectionString();
            var builder = new NpgsqlConnectionStringBuilder(connectionString);
            var databaseName = builder.Database
                ?? throw new InvalidOperationException("Database name not found in connection string.");

            builder.Database = "postgres";

            using var adminConnection = new NpgsqlConnection(builder.ConnectionString);
            adminConnection.Open();

            using var checkCmd = adminConnection.CreateCommand();
            checkCmd.CommandText = "SELECT 1 FROM pg_database WHERE datname = @dbname";
            checkCmd.Parameters.AddWithValue("dbname", databaseName);

            var exists = checkCmd.ExecuteScalar() is not null;
            if (!exists)
            {
                using var createCmd = adminConnection.CreateCommand();
                createCmd.CommandText = $"CREATE DATABASE \"{databaseName}\"";
                createCmd.ExecuteNonQuery();
            }
        }
    }
}

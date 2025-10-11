using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softela.PestManagement.Infrastructure.Database.Connections
{
    public interface IDatabaseConnection
    {
        IDbConnection GetConnection();
        string GetConnectionString();
    }
}

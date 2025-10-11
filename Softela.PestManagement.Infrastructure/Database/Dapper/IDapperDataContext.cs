using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softela.PestManagement.Infrastructure.Database.Dapper
{
    public interface IDapperDataContext
    {
        IDbConnection? Connection { get; }
        IDbTransaction? Transaction { get; set; }
    }
}

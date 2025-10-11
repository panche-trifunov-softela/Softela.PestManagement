using Dapper;
using Softela.PestManagement.Application.Repositories;
using Softela.PestManagement.Domain.Entities;
using Softela.PestManagement.Infrastructure.Database.Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Softela.PestManagement.Infrastructure.Database.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IDapperDataContext _dapperDataContext;

        public RoleRepository(IDapperDataContext dapperDataContext)
        {
            _dapperDataContext = dapperDataContext;
        }

        public async Task<List<Role>> GetRolesByUserIdAsync(int userId)
        {
            var roles = await _dapperDataContext.Connection!
                .QueryAsync<Role>(
                    "GetRolesByUserId",
                    new { UserId = userId },
                    _dapperDataContext.Transaction,
                    commandType: CommandType.StoredProcedure
                );
            return roles.AsList();
        }
    }
}

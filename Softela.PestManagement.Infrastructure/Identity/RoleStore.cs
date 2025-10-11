using Microsoft.AspNetCore.Identity;
using Softela.PestManagement.Domain.Entities;
using Softela.PestManagement.Infrastructure.Database.Dapper;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Dapper;

namespace Softela.PestManagement.Infrastructure.Identity
{
    public class RoleStore : IRoleStore<Role>
    {
        private readonly IDapperDataContext _dapperDataContext;

        public RoleStore(IDapperDataContext dapperDataContext)
        {
            _dapperDataContext = dapperDataContext;
        }

        public async Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken)
        {
            var parameters = new
            {
                role.Name,
                role.NormalizedName
            };

            role.Id = await _dapperDataContext.Connection!.QuerySingleAsync<int>(
                "UpsertRole",
                parameters,
                _dapperDataContext.Transaction,
                commandType: CommandType.StoredProcedure
            );
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken)
        {
            await _dapperDataContext.Connection!.ExecuteAsync(
                "DeleteRole",
                new { role.Id },
                _dapperDataContext.Transaction,
                commandType: CommandType.StoredProcedure
            );
            return IdentityResult.Success;
        }

        public async Task<Role> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            return await _dapperDataContext.Connection!.QuerySingleOrDefaultAsync<Role>(
                "GetRoleById",
                new { Id = int.Parse(roleId) },
                _dapperDataContext.Transaction,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<Role> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            return await _dapperDataContext.Connection!.QuerySingleOrDefaultAsync<Role>(
                "GetRoleByNormalizedName",
                new { NormalizedName = normalizedRoleName },
                _dapperDataContext.Transaction,
                commandType: CommandType.StoredProcedure
            );
        }

        public Task<string> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.NormalizedName);
        }

        public Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Id.ToString());
        }

        public Task<string> GetRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Name);
        }

        public Task SetNormalizedRoleNameAsync(Role role, string normalizedName, CancellationToken cancellationToken)
        {
            role.NormalizedName = normalizedName;
            return Task.CompletedTask;
        }

        public Task SetRoleNameAsync(Role role, string roleName, CancellationToken cancellationToken)
        {
            role.Name = roleName;
            return Task.CompletedTask;
        }

        public async Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken)
        {
            var parameters = new
            {
                role.Id,
                role.Name,
                role.NormalizedName
            };

            await _dapperDataContext.Connection!.ExecuteAsync(
                "UpsertRole",
                parameters,
                _dapperDataContext.Transaction,
                commandType: CommandType.StoredProcedure
            );
            return IdentityResult.Success;
        }

        public void Dispose()
        {
            // No unmanaged resources to dispose
        }
    }
}
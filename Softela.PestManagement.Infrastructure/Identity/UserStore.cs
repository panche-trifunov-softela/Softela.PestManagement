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
    public class UserStore : IUserStore<User>
    {
        private readonly IDapperDataContext _dapperDataContext;

        public UserStore(IDapperDataContext dapperDataContext)
        {
            _dapperDataContext = dapperDataContext;
        }

        public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            var parameters = new
            {
                user.UserName,
                user.NormalizedUserName,
                user.Email,
                user.NormalizedEmail,
                user.EmailConfirmed,
                user.PasswordHash,
                user.IsActive,
                user.IsDeleted
            };

            user.Id = await _dapperDataContext.Connection!.QuerySingleAsync<int>(
                "UpsertUser",
                parameters,
                _dapperDataContext.Transaction,
                commandType: CommandType.StoredProcedure
            );
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            await _dapperDataContext.Connection!.ExecuteAsync(
                "DeleteUser",
                new { user.Id },
                _dapperDataContext.Transaction,
                commandType: CommandType.StoredProcedure
            );
            return IdentityResult.Success;
        }

        public async Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            return await _dapperDataContext.Connection!.QuerySingleOrDefaultAsync<User>(
                "GetUserById",
                new { Id = int.Parse(userId) },
                _dapperDataContext.Transaction,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return await _dapperDataContext.Connection!.QuerySingleOrDefaultAsync<User>(
                "GetUserByNormalizedUserName",
                new { NormalizedUserName = normalizedUserName },
                _dapperDataContext.Transaction,
                commandType: CommandType.StoredProcedure
            );
        }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizedUserName);
        }

        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName);
        }

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            user.NormalizedUserName = normalizedName;
            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            user.UserName = userName;
            return Task.CompletedTask;
        }

        public async Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            var parameters = new
            {
                user.Id,
                user.UserName,
                user.NormalizedUserName,
                user.Email,
                user.NormalizedEmail,
                user.EmailConfirmed,
                user.PasswordHash,
                user.IsActive,
                user.IsDeleted
            };

            await _dapperDataContext.Connection!.ExecuteAsync(
                "UpsertUser",
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
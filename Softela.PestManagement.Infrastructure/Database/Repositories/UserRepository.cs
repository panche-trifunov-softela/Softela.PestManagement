using Dapper;
using Softela.PestManagement.Application.Repositories;
using Softela.PestManagement.Domain.Entities;
using Softela.PestManagement.Infrastructure.Database.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softela.PestManagement.Infrastructure.Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDapperDataContext _dapperDataContext;

        public UserRepository(IDapperDataContext dapperDataContext)
        {
            _dapperDataContext = dapperDataContext;
        }

        public async Task CreateUserAsync(User user)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", user.UserId, DbType.Guid, ParameterDirection.Input);
            parameters.Add("@UserName", user.UserName, DbType.String, ParameterDirection.Input);
            parameters.Add("@CreatedAt", user.CreatedAt, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@ModifiedAt", user.ModifiedAt, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@Email", user.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("@PasswordHash", user.PasswordHash, DbType.String, ParameterDirection.Input);
            parameters.Add("@NormalizedUserName", user.NormalizedUserName, DbType.String, ParameterDirection.Input);
            parameters.Add("@NormalizedEmail", user.NormalizedEmail, DbType.String, ParameterDirection.Input);
            parameters.Add("@EmailConfirmed", user.EmailConfirmed, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@IsActive", user.IsActive, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@IsDeleted", user.IsDeleted, DbType.Boolean, ParameterDirection.Input);

            await _dapperDataContext.Connection!.QueryAsync
            (
                sql: $"InsertUser",
                param: parameters,
                commandType: CommandType.StoredProcedure,
                transaction: _dapperDataContext.Transaction,
                commandTimeout: _dapperDataContext.Connection!.ConnectionTimeout
            ).ConfigureAwait(false);
        }
    }
}

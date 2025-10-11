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
    public class AccountRepository : IAccountRepository
    {
        private readonly IDapperDataContext _dapperDataContext;

        public AccountRepository(IDapperDataContext dapperDataContext)
        {
            _dapperDataContext = dapperDataContext;
        }

        public async Task CreateUpdateAccountAsync(Account account)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", account.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@Id", account.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@CreatedAt", account.CreatedAt, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@ModifiedAt", account.ModifiedAt, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@IsActive", account.IsActive, DbType.Boolean, ParameterDirection.Input);

            await _dapperDataContext.Connection!.QueryAsync
            (
                sql: $"UpsertAccount",
                param: parameters,
                commandType: CommandType.StoredProcedure,
                transaction: _dapperDataContext.Transaction,
                commandTimeout: _dapperDataContext.Connection!.ConnectionTimeout
            ).ConfigureAwait(false);
        }

        public void DeleteAccount(int id)
        {
            throw new NotImplementedException();
        }

        public Account GetAccountAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Account>> GetAccountsAsync()
        {
            var accounts = await _dapperDataContext.Connection!
                .QueryAsync<Account>(
                    sql: "GetAccounts",
                    param: null,
                    commandType: CommandType.StoredProcedure,
                    transaction: _dapperDataContext.Transaction,
                    commandTimeout: _dapperDataContext.Connection!.ConnectionTimeout
                );
            return accounts.ToList();
        }
    }
}

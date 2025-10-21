using Dapper;
using Softela.PestManagement.Application.Repositories;
using Softela.PestManagement.Domain.Entities;
using Softela.PestManagement.Infrastructure.Database.Dapper;
using System.Data;

namespace Softela.PestManagement.Infrastructure.Database.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDapperDataContext _dapperDataContext;

        public AccountRepository(IDapperDataContext dapperDataContext)
        {
            _dapperDataContext = dapperDataContext;
        }

        public async Task<int> CreateAsync(Account account)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@CompanyId", account.CompanyId);
            parameters.Add("@AccountNum", account.AccountNum);
            parameters.Add("@AccountType", account.AccountType);
            parameters.Add("@BillingAddressId", account.BillingAddressId);
            parameters.Add("@BillingContactId", account.BillingContactId);
            parameters.Add("@BillingCenterId", account.BillingCenterId);
            parameters.Add("@LocaleId", account.LocaleId);
            parameters.Add("@SendInvoice", account.SendInvoice);
            parameters.Add("@EmailInvoice", account.EmailInvoice);
            parameters.Add("@SendStatement", account.SendStatement);
            parameters.Add("@EmailStatement", account.EmailStatement);
            parameters.Add("@SendRenewal", account.SendRenewal);
            parameters.Add("@EmailRenewal", account.EmailRenewal);
            parameters.Add("@MarketingEmail", account.MarketingEmail);
            parameters.Add("@NotificationsMail", account.NotificationsMail);
            parameters.Add("@Instructions", account.Instructions);
            parameters.Add("@PrimaryNote", account.PrimaryNote);
            parameters.Add("@SecondaryNote", account.SecondaryNote);
            parameters.Add("@Name", account.Name);
            parameters.Add("@IsActive", account.IsActive);
            parameters.Add("@IsDeleted", account.IsDeleted);
            parameters.Add("@MasterAccountId", account.MasterAccountId);
            parameters.Add("@MasterAccountSubId", account.MasterAccountSubId);
            parameters.Add("@RegistrationNum", account.RegistrationNum);
            parameters.Add("@DiscountTypeId", account.DiscountTypeId);
            parameters.Add("@AccountManagerId", account.AccountManagerId);
            parameters.Add("@CreatedAt", account.CreatedAt);
            parameters.Add("@ModifiedAt", account.ModifiedAt);
            parameters.Add("@CreatedBy", account.CreatedBy);
            parameters.Add("@ModifiedBy", account.ModifiedBy);

            var id = await _dapperDataContext.Connection!.ExecuteScalarAsync<int>(
                sql: "CreateAccount",
                param: parameters,
                transaction: _dapperDataContext.Transaction,
                commandType: CommandType.StoredProcedure,
                commandTimeout: _dapperDataContext.Connection.ConnectionTimeout
            ).ConfigureAwait(false);

            return id;
        }

        public async Task<Account?> GetByIdAsync(int id)
        {
            var account = await _dapperDataContext.Connection!.QueryFirstOrDefaultAsync<Account>(
                sql: "GetAccountById",
                param: new { Id = id },
                transaction: _dapperDataContext.Transaction,
                commandType: CommandType.StoredProcedure,
                commandTimeout: _dapperDataContext.Connection.ConnectionTimeout
            ).ConfigureAwait(false);

            return account;
        }

        public async Task<Account?> GetByAccountNumAsync(string accountNum)
        {
            var account = await _dapperDataContext.Connection!.QueryFirstOrDefaultAsync<Account>(
                sql: "GetAccountByAccountNum",
                param: new { AccountNum = accountNum },
                transaction: _dapperDataContext.Transaction,
                commandType: CommandType.StoredProcedure,
                commandTimeout: _dapperDataContext.Connection.ConnectionTimeout
            ).ConfigureAwait(false);

            return account;
        }

        public async Task<IEnumerable<Account>> GetAllAsync(int companyId)
        {
            var accounts = await _dapperDataContext.Connection!.QueryAsync<Account>(
                sql: "GetAllAccounts",
                param: new { CompanyId = companyId },
                transaction: _dapperDataContext.Transaction,
                commandType: CommandType.StoredProcedure,
                commandTimeout: _dapperDataContext.Connection.ConnectionTimeout
            ).ConfigureAwait(false);

            return accounts;
        }

        public async Task<IEnumerable<Account>> SearchAsync(int companyId, string? searchTerm, short? isActive)
        {
            var accounts = await _dapperDataContext.Connection!.QueryAsync<Account>(
                sql: "SearchAccounts",
                param: new { CompanyId = companyId, SearchTerm = searchTerm, IsActive = isActive },
                transaction: _dapperDataContext.Transaction,
                commandType: CommandType.StoredProcedure,
                commandTimeout: _dapperDataContext.Connection.ConnectionTimeout
            ).ConfigureAwait(false);

            return accounts;
        }

        public async Task UpdateAsync(Account account)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", account.Id);
            parameters.Add("@CompanyId", account.CompanyId);
            parameters.Add("@AccountNum", account.AccountNum);
            parameters.Add("@AccountType", account.AccountType);
            parameters.Add("@BillingAddressId", account.BillingAddressId);
            parameters.Add("@BillingContactId", account.BillingContactId);
            parameters.Add("@BillingCenterId", account.BillingCenterId);
            parameters.Add("@LocaleId", account.LocaleId);
            parameters.Add("@SendInvoice", account.SendInvoice);
            parameters.Add("@EmailInvoice", account.EmailInvoice);
            parameters.Add("@SendStatement", account.SendStatement);
            parameters.Add("@EmailStatement", account.EmailStatement);
            parameters.Add("@SendRenewal", account.SendRenewal);
            parameters.Add("@EmailRenewal", account.EmailRenewal);
            parameters.Add("@MarketingEmail", account.MarketingEmail);
            parameters.Add("@NotificationsMail", account.NotificationsMail);
            parameters.Add("@Instructions", account.Instructions);
            parameters.Add("@PrimaryNote", account.PrimaryNote);
            parameters.Add("@SecondaryNote", account.SecondaryNote);
            parameters.Add("@Name", account.Name);
            parameters.Add("@IsActive", account.IsActive);
            parameters.Add("@IsDeleted", account.IsDeleted);
            parameters.Add("@MasterAccountId", account.MasterAccountId);
            parameters.Add("@MasterAccountSubId", account.MasterAccountSubId);
            parameters.Add("@RegistrationNum", account.RegistrationNum);
            parameters.Add("@DiscountTypeId", account.DiscountTypeId);
            parameters.Add("@AccountManagerId", account.AccountManagerId);
            parameters.Add("@ModifiedAt", account.ModifiedAt);
            parameters.Add("@ModifiedBy", account.ModifiedBy);

            await _dapperDataContext.Connection!.ExecuteAsync(
                sql: "UpdateAccount",
                param: parameters,
                transaction: _dapperDataContext.Transaction,
                commandType: CommandType.StoredProcedure,
                commandTimeout: _dapperDataContext.Connection.ConnectionTimeout
            ).ConfigureAwait(false);
        }

        public async Task DeleteAsync(int id)
        {
            await _dapperDataContext.Connection!.ExecuteAsync(
                sql: "DeleteAccount",
                param: new { Id = id },
                transaction: _dapperDataContext.Transaction,
                commandType: CommandType.StoredProcedure,
                commandTimeout: _dapperDataContext.Connection.ConnectionTimeout
            ).ConfigureAwait(false);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var exists = await _dapperDataContext.Connection!.ExecuteScalarAsync<bool>(
                sql: "CheckAccountExists",
                param: new { Id = id },
                transaction: _dapperDataContext.Transaction,
                commandType: CommandType.StoredProcedure,
                commandTimeout: _dapperDataContext.Connection.ConnectionTimeout
            ).ConfigureAwait(false);

            return exists;
        }

        public async Task<bool> AccountNumExistsAsync(string accountNum, int companyId, int? excludeId = null)
        {
            var exists = await _dapperDataContext.Connection!.ExecuteScalarAsync<bool>(
                sql: "CheckAccountNumExists",
                param: new { AccountNum = accountNum, CompanyId = companyId, ExcludeId = excludeId },
                transaction: _dapperDataContext.Transaction,
                commandType: CommandType.StoredProcedure,
                commandTimeout: _dapperDataContext.Connection.ConnectionTimeout
            ).ConfigureAwait(false);

            return exists;
        }
    }
}

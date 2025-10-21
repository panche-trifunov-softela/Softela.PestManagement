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
            var sql = @"
                INSERT INTO Accounts (
                    CompanyId, AccountNum, AccountType, BillingAddressId, BillingContactId,
                    BillingCenterId, LocaleId,
                    SendInvoice, EmailInvoice, SendStatement, EmailStatement,
                    SendRenewal, EmailRenewal, MarketingEmail, NotificationsMail,
                    Instructions, PrimaryNote, SecondaryNote,
                    Name, IsActive, IsDeleted, MasterAccountId, MasterAccountSubId, RegistrationNum,
                    DiscountTypeId, AccountManagerId,
                    CreatedAt, ModifiedAt, CreatedBy, ModifiedBy
                ) VALUES (
                    @CompanyId, @AccountNum, @AccountType, @BillingAddressId, @BillingContactId,
                    @BillingCenterId, @LocaleId,
                    @SendInvoice, @EmailInvoice, @SendStatement, @EmailStatement,
                    @SendRenewal, @EmailRenewal, @MarketingEmail, @NotificationsMail,
                    @Instructions, @PrimaryNote, @SecondaryNote,
                    @Name, @IsActive, @IsDeleted, @MasterAccountId, @MasterAccountSubId, @RegistrationNum,
                    @DiscountTypeId, @AccountManagerId,
                    @CreatedAt, @ModifiedAt, @CreatedBy, @ModifiedBy
                );
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            var id = await _dapperDataContext.Connection!.ExecuteScalarAsync<int>(
                sql: sql,
                param: account,
                transaction: _dapperDataContext.Transaction,
                commandTimeout: _dapperDataContext.Connection.ConnectionTimeout
            ).ConfigureAwait(false);

            return id;
        }

        public async Task<Account?> GetByIdAsync(int id)
        {
            var sql = @"
                SELECT * FROM Accounts WHERE Id = @Id";

            var account = await _dapperDataContext.Connection!.QueryFirstOrDefaultAsync<Account>(
                sql: sql,
                param: new { Id = id },
                transaction: _dapperDataContext.Transaction,
                commandTimeout: _dapperDataContext.Connection.ConnectionTimeout
            ).ConfigureAwait(false);

            return account;
        }

        public async Task<Account?> GetByAccountNumAsync(string accountNum)
        {
            var sql = @"
                SELECT * FROM Accounts WHERE AccountNum = @AccountNum";

            var account = await _dapperDataContext.Connection!.QueryFirstOrDefaultAsync<Account>(
                sql: sql,
                param: new { AccountNum = accountNum },
                transaction: _dapperDataContext.Transaction,
                commandTimeout: _dapperDataContext.Connection.ConnectionTimeout
            ).ConfigureAwait(false);

            return account;
        }

        public async Task<IEnumerable<Account>> GetAllAsync(int companyId)
        {
            var sql = @"
                SELECT * FROM Accounts
                WHERE CompanyId = @CompanyId
                ORDER BY AccountNum";

            var accounts = await _dapperDataContext.Connection!.QueryAsync<Account>(
                sql: sql,
                param: new { CompanyId = companyId },
                transaction: _dapperDataContext.Transaction,
                commandTimeout: _dapperDataContext.Connection.ConnectionTimeout
            ).ConfigureAwait(false);

            return accounts;
        }

        public async Task<IEnumerable<Account>> SearchAsync(int companyId, string? searchTerm, short? isActive)
        {
            var sql = @"
                SELECT * FROM Accounts
                WHERE CompanyId = @CompanyId
                AND (@SearchTerm IS NULL OR AccountNum LIKE '%' + @SearchTerm + '%')
                AND (@IsActive IS NULL OR IsActive = @IsActive)
                ORDER BY AccountNum";

            var accounts = await _dapperDataContext.Connection!.QueryAsync<Account>(
                sql: sql,
                param: new { CompanyId = companyId, SearchTerm = searchTerm, IsActive = isActive },
                transaction: _dapperDataContext.Transaction,
                commandTimeout: _dapperDataContext.Connection.ConnectionTimeout
            ).ConfigureAwait(false);

            return accounts;
        }

        public async Task UpdateAsync(Account account)
        {
            var sql = @"
                UPDATE Accounts SET
                    CompanyId = @CompanyId,
                    AccountNum = @AccountNum,
                    AccountType = @AccountType,
                    BillingAddressId = @BillingAddressId,
                    BillingContactId = @BillingContactId,
                    BillingCenterId = @BillingCenterId,
                    LocaleId = @LocaleId,
                    SendInvoice = @SendInvoice,
                    EmailInvoice = @EmailInvoice,
                    SendStatement = @SendStatement,
                    EmailStatement = @EmailStatement,
                    SendRenewal = @SendRenewal,
                    EmailRenewal = @EmailRenewal,
                    MarketingEmail = @MarketingEmail,
                    NotificationsMail = @NotificationsMail,
                    Instructions = @Instructions,
                    PrimaryNote = @PrimaryNote,
                    SecondaryNote = @SecondaryNote,
                    Name = @Name,
                    IsActive = @IsActive,
                    IsDeleted = @IsDeleted,
                    MasterAccountId = @MasterAccountId,
                    MasterAccountSubId = @MasterAccountSubId,
                    RegistrationNum = @RegistrationNum,
                    DiscountTypeId = @DiscountTypeId,
                    AccountManagerId = @AccountManagerId,
                    ModifiedAt = @ModifiedAt,
                    ModifiedBy = @ModifiedBy
                WHERE Id = @Id";

            await _dapperDataContext.Connection!.ExecuteAsync(
                sql: sql,
                param: account,
                transaction: _dapperDataContext.Transaction,
                commandTimeout: _dapperDataContext.Connection.ConnectionTimeout
            ).ConfigureAwait(false);
        }

        public async Task DeleteAsync(int id)
        {
            var sql = @"
                DELETE FROM Accounts WHERE Id = @Id";

            await _dapperDataContext.Connection!.ExecuteAsync(
                sql: sql,
                param: new { Id = id },
                transaction: _dapperDataContext.Transaction,
                commandTimeout: _dapperDataContext.Connection.ConnectionTimeout
            ).ConfigureAwait(false);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var sql = @"
                SELECT CAST(CASE WHEN EXISTS(SELECT 1 FROM Accounts WHERE Id = @Id) THEN 1 ELSE 0 END AS BIT)";

            var exists = await _dapperDataContext.Connection!.ExecuteScalarAsync<bool>(
                sql: sql,
                param: new { Id = id },
                transaction: _dapperDataContext.Transaction,
                commandTimeout: _dapperDataContext.Connection.ConnectionTimeout
            ).ConfigureAwait(false);

            return exists;
        }

        public async Task<bool> AccountNumExistsAsync(string accountNum, int companyId, int? excludeId = null)
        {
            var sql = @"
                SELECT CAST(CASE WHEN EXISTS(
                    SELECT 1 FROM Accounts
                    WHERE AccountNum = @AccountNum
                    AND CompanyId = @CompanyId
                    AND (@ExcludeId IS NULL OR Id != @ExcludeId)
                ) THEN 1 ELSE 0 END AS BIT)";

            var exists = await _dapperDataContext.Connection!.ExecuteScalarAsync<bool>(
                sql: sql,
                param: new { AccountNum = accountNum, CompanyId = companyId, ExcludeId = excludeId },
                transaction: _dapperDataContext.Transaction,
                commandTimeout: _dapperDataContext.Connection.ConnectionTimeout
            ).ConfigureAwait(false);

            return exists;
        }
    }
}

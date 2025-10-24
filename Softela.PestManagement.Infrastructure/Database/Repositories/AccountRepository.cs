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

        public async Task<Account?> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Accounts WHERE Id = @Id AND IsDeleted = 0";
            return await _dapperDataContext.Connection!.QueryFirstOrDefaultAsync<Account>(
                sql: sql,
                param: new { Id = id },
                transaction: _dapperDataContext.Transaction
            );
        }

        public async Task<Account?> GetByAccountNumAsync(string accountNum)
        {
            var sql = "SELECT * FROM Accounts WHERE AccountNum = @AccountNum AND IsDeleted = 0";
            return await _dapperDataContext.Connection!.QueryFirstOrDefaultAsync<Account>(
                sql: sql,
                param: new { AccountNum = accountNum },
                transaction: _dapperDataContext.Transaction
            );
        }

        public async Task<List<Account>> GetAllAsync(int companyId)
        {
            var sql = "SELECT * FROM Accounts WHERE CompanyId = @CompanyId AND IsDeleted = 0 ORDER BY Name";
            var accounts = await _dapperDataContext.Connection!.QueryAsync<Account>(
                sql: sql,
                param: new { CompanyId = companyId },
                transaction: _dapperDataContext.Transaction
            );
            return accounts.ToList();
        }

        public async Task<List<Account>> SearchAsync(int companyId, string? searchTerm, short? isActive)
        {
            var sql = @"SELECT * FROM Accounts
                        WHERE CompanyId = @CompanyId
                        AND IsDeleted = 0
                        AND (@SearchTerm IS NULL OR Name LIKE '%' + @SearchTerm + '%' OR AccountNum LIKE '%' + @SearchTerm + '%')
                        AND (@IsActive IS NULL OR IsActive = @IsActive)
                        ORDER BY Name";

            var accounts = await _dapperDataContext.Connection!.QueryAsync<Account>(
                sql: sql,
                param: new { CompanyId = companyId, SearchTerm = searchTerm, IsActive = isActive },
                transaction: _dapperDataContext.Transaction
            );
            return accounts.ToList();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var sql = "SELECT COUNT(1) FROM Accounts WHERE Id = @Id AND IsDeleted = 0";
            var count = await _dapperDataContext.Connection!.ExecuteScalarAsync<int>(
                sql: sql,
                param: new { Id = id },
                transaction: _dapperDataContext.Transaction
            );
            return count > 0;
        }

        public async Task<bool> AccountNumExistsAsync(string accountNum, int companyId, int? excludeId)
        {
            var sql = @"SELECT COUNT(1) FROM Accounts
                        WHERE AccountNum = @AccountNum
                        AND CompanyId = @CompanyId
                        AND IsDeleted = 0
                        AND (@ExcludeId IS NULL OR Id != @ExcludeId)";

            var count = await _dapperDataContext.Connection!.ExecuteScalarAsync<int>(
                sql: sql,
                param: new { AccountNum = accountNum, CompanyId = companyId, ExcludeId = excludeId },
                transaction: _dapperDataContext.Transaction
            );
            return count > 0;
        }

        public async Task<int> UpsertAsync(Account account)
        {
            if (account.Id == 0)
            {
                // Insert
                var sql = @"INSERT INTO Accounts (Name, CompanyId, AccountNum, AccountType, BillingAddressId, BillingContactId,
                            BillingCenterId, LocaleId, SendInvoice, EmailInvoice, SendStatement, EmailStatement, SendRenewal,
                            EmailRenewal, MarketingEmail, NotificationsMail, Instructions, PrimaryNote, SecondaryNote, IsActive,
                            IsDeleted, MasterAccountId, MasterAccountSubId, RegistrationNum, DiscountTypeId, AccountManagerId,
                            UtcTimestamp, CreatedBy, UtcLastChanged, LastChangedBy)
                            VALUES (@Name, @CompanyId, @AccountNum, @AccountType, @BillingAddressId, @BillingContactId,
                            @BillingCenterId, @LocaleId, @SendInvoice, @EmailInvoice, @SendStatement, @EmailStatement, @SendRenewal,
                            @EmailRenewal, @MarketingEmail, @NotificationsMail, @Instructions, @PrimaryNote, @SecondaryNote, @IsActive,
                            @IsDeleted, @MasterAccountId, @MasterAccountSubId, @RegistrationNum, @DiscountTypeId, @AccountManagerId,
                            GETUTCDATE(), @CreatedBy, GETUTCDATE(), @LastChangedBy);
                            SELECT CAST(SCOPE_IDENTITY() AS INT);";

                var id = await _dapperDataContext.Connection!.ExecuteScalarAsync<int>(
                    sql: sql,
                    param: account,
                    transaction: _dapperDataContext.Transaction
                );
                return id;
            }
            else
            {
                // Update
                var sql = @"UPDATE Accounts SET
                            Name = @Name,
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
                            IsActive = @IsActive,
                            MasterAccountId = @MasterAccountId,
                            MasterAccountSubId = @MasterAccountSubId,
                            RegistrationNum = @RegistrationNum,
                            DiscountTypeId = @DiscountTypeId,
                            AccountManagerId = @AccountManagerId,
                            UtcLastChanged = GETUTCDATE(),
                            LastChangedBy = @LastChangedBy
                            WHERE Id = @Id AND IsDeleted = 0";

                await _dapperDataContext.Connection!.ExecuteAsync(
                    sql: sql,
                    param: account,
                    transaction: _dapperDataContext.Transaction
                );
                return account.Id;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var sql = "UPDATE Accounts SET IsDeleted = 1, UtcLastChanged = GETUTCDATE() WHERE Id = @Id";
            await _dapperDataContext.Connection!.ExecuteAsync(
                sql: sql,
                param: new { Id = id },
                transaction: _dapperDataContext.Transaction
            );
        }
    }
}

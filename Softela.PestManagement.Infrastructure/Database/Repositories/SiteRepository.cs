using Dapper;
using Softela.PestManagement.Application.Repositories;
using Softela.PestManagement.Domain.Entities;
using Softela.PestManagement.Infrastructure.Database.Dapper;
using System.Data;

namespace Softela.PestManagement.Infrastructure.Database.Repositories
{
    public class SiteRepository : ISiteRepository
    {
        private readonly IDapperDataContext _dapperDataContext;

        public SiteRepository(IDapperDataContext dapperDataContext)
        {
            _dapperDataContext = dapperDataContext;
        }

        public async Task<Site?> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Sites WHERE Id = @Id AND IsDeleted = 0";
            return await _dapperDataContext.Connection!.QueryFirstOrDefaultAsync<Site>(
                sql: sql,
                param: new { Id = id },
                transaction: _dapperDataContext.Transaction
            );
        }

        public async Task<List<Site>> GetByAccountIdAsync(int accountId)
        {
            var sql = "SELECT * FROM Sites WHERE AccountId = @AccountId AND IsDeleted = 0";
            var sites = await _dapperDataContext.Connection!.QueryAsync<Site>(
                sql: sql,
                param: new { AccountId = accountId },
                transaction: _dapperDataContext.Transaction
            );
            return sites.ToList();
        }

        public async Task<List<Site>> GetAllAsync()
        {
            var sql = "SELECT * FROM Sites WHERE IsDeleted = 0";
            var sites = await _dapperDataContext.Connection!.QueryAsync<Site>(
                sql: sql,
                transaction: _dapperDataContext.Transaction
            );
            return sites.ToList();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var sql = "SELECT COUNT(1) FROM Sites WHERE Id = @Id AND IsDeleted = 0";
            var count = await _dapperDataContext.Connection!.ExecuteScalarAsync<int>(
                sql: sql,
                param: new { Id = id },
                transaction: _dapperDataContext.Transaction
            );
            return count > 0;
        }

        public async Task<int> UpsertAsync(Site site)
        {
            if (site.Id == 0)
            {
                // Insert
                var sql = @"INSERT INTO Sites (AccountId, AddressId, PrimaryContactId, PropertyType, Notes, Latitude, Longitude,
                            Instructions, TaxTypeId, UtcTimestamp, CreatedBy, UtcLastChanged, LastChangedBy, SalesPersonId, SiteReferenceNumber,
                            SendCompletedWoMethod, SendCompletedWoTo, Facility, FacilityType, SiteManagerId, IsDeleted)
                            VALUES (@AccountId, @AddressId, @PrimaryContactId, @PropertyType, @Notes, @Latitude, @Longitude,
                            @Instructions, @TaxTypeId, GETUTCDATE(), @CreatedBy, GETUTCDATE(), @LastChangedBy, @SalesPersonId, @SiteReferenceNumber,
                            @SendCompletedWoMethod, @SendCompletedWoTo, @Facility, @FacilityType, @SiteManagerId, @IsDeleted);
                            SELECT CAST(SCOPE_IDENTITY() AS INT);";

                var id = await _dapperDataContext.Connection!.ExecuteScalarAsync<int>(
                    sql: sql,
                    param: site,
                    transaction: _dapperDataContext.Transaction
                );
                return id;
            }
            else
            {
                // Update
                var sql = @"UPDATE Sites SET
                            AccountId = @AccountId,
                            AddressId = @AddressId,
                            PrimaryContactId = @PrimaryContactId,
                            PropertyType = @PropertyType,
                            Notes = @Notes,
                            Latitude = @Latitude,
                            Longitude = @Longitude,
                            Instructions = @Instructions,
                            TaxTypeId = @TaxTypeId,
                            UtcLastChanged = GETUTCDATE(),
                            LastChangedBy = @LastChangedBy,
                            SalesPersonId = @SalesPersonId,
                            SiteReferenceNumber = @SiteReferenceNumber,
                            SendCompletedWoMethod = @SendCompletedWoMethod,
                            SendCompletedWoTo = @SendCompletedWoTo,
                            Facility = @Facility,
                            FacilityType = @FacilityType,
                            SiteManagerId = @SiteManagerId
                            WHERE Id = @Id AND IsDeleted = 0";

                await _dapperDataContext.Connection!.ExecuteAsync(
                    sql: sql,
                    param: site,
                    transaction: _dapperDataContext.Transaction
                );
                return site.Id;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var sql = "UPDATE Sites SET IsDeleted = 1, UtcLastChanged = GETUTCDATE() WHERE Id = @Id";
            await _dapperDataContext.Connection!.ExecuteAsync(
                sql: sql,
                param: new { Id = id },
                transaction: _dapperDataContext.Transaction
            );
        }
    }
}

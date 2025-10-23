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
            _dapperDataContext = dapperDataContext ?? throw new ArgumentNullException(nameof(dapperDataContext));
        }

        public async Task<int> UpsertAsync(Site site)
        {
            if (site is null) throw new ArgumentNullException(nameof(site));
            var conn = _dapperDataContext.Connection ?? throw new InvalidOperationException("Database connection is not available.");

            var parameters = new DynamicParameters();
            parameters.Add("@Id", site.Id > 0 ? site.Id : (int?)null);
            parameters.Add("@AddressId", site.AddressId);
            parameters.Add("@PrimaryContactId", site.PrimaryContactId);
            parameters.Add("@PropertyType", site.PropertyType);
            parameters.Add("@Notes", site.Notes);
            parameters.Add("@Latitude", site.Latitude);
            parameters.Add("@Longitude", site.Longitude);
            parameters.Add("@Instructions", site.Instructions);
            parameters.Add("@TaxTypeId", site.TaxTypeId);
            parameters.Add("@SalespersonId", site.SalespersonId);
            parameters.Add("@SiteReferenceNumber", site.SiteReferenceNumber);
            parameters.Add("@SendCompletedWoMethod", site.SendCompletedWoMethod);
            parameters.Add("@SendCompletedWoTo", site.SendCompletedWoTo);
            parameters.Add("@Facility", site.Facility);
            parameters.Add("@FacilityType", site.FacilityType);
            parameters.Add("@SiteManagerId", site.SiteManagerId);
            parameters.Add("@ReferenceNumber", site.ReferenceNumber);
            parameters.Add("@IsDeleted", site.IsDeleted);
            parameters.Add("@CreatedAt", site.CreatedAt);
            parameters.Add("@ModifiedAt", site.ModifiedAt);
            parameters.Add("@CreatedBy", site.CreatedBy);
            parameters.Add("@ModifiedBy", site.ModifiedBy);

            var id = await conn.ExecuteScalarAsync<int>(
                sql: "UpsertSite",
                param: parameters,
                transaction: _dapperDataContext.Transaction,
                commandType: CommandType.StoredProcedure,
                commandTimeout: conn.ConnectionTimeout
            ).ConfigureAwait(false);

            return id;
        }

        public async Task<Site?> GetByIdAsync(int id)
        {
            var conn = _dapperDataContext.Connection ?? throw new InvalidOperationException("Database connection is not available.");

            var site = await conn.QueryFirstOrDefaultAsync<Site>(
                sql: "GetSiteById",
                param: new { Id = id },
                transaction: _dapperDataContext.Transaction,
                commandType: CommandType.StoredProcedure,
                commandTimeout: conn.ConnectionTimeout
            ).ConfigureAwait(false);

            return site;
        }

        public async Task<Site?> GetByReferenceNumberAsync(string referenceNumber)
        {
            var conn = _dapperDataContext.Connection ?? throw new InvalidOperationException("Database connection is not available.");

            var site = await conn.QueryFirstOrDefaultAsync<Site>(
                sql: "GetSiteByReferenceNumber",
                param: new { ReferenceNumber = referenceNumber },
                transaction: _dapperDataContext.Transaction,
                commandType: CommandType.StoredProcedure,
                commandTimeout: conn.ConnectionTimeout
            ).ConfigureAwait(false);

            return site;
        }

        public async Task<IEnumerable<Site>> GetAllAsync()
        {
            var conn = _dapperDataContext.Connection ?? throw new InvalidOperationException("Database connection is not available.");

            var sites = await conn.QueryAsync<Site>(
                sql: "GetSites",
                param: null,
                transaction: _dapperDataContext.Transaction,
                commandType: CommandType.StoredProcedure,
                commandTimeout: conn.ConnectionTimeout
            ).ConfigureAwait(false);

            return sites;
        }

        public async Task<IEnumerable<Site>> GetByAccountIdAsync(int accountId)
        {
            var conn = _dapperDataContext.Connection ?? throw new InvalidOperationException("Database connection is not available.");

            var sites = await conn.QueryAsync<Site>(
                sql: "GetSitesByAccountId",
                param: new { AccountId = accountId },
                transaction: _dapperDataContext.Transaction,
                commandType: CommandType.StoredProcedure,
                commandTimeout: conn.ConnectionTimeout
            ).ConfigureAwait(false);

            return sites;
        }

        public async Task DeleteAsync(int id)
        {
            var conn = _dapperDataContext.Connection ?? throw new InvalidOperationException("Database connection is not available.");

            await conn.ExecuteAsync(
                sql: "DeleteSite",
                param: new { Id = id, ModifiedAt = DateTime.UtcNow, ModifiedBy = Guid.NewGuid() }, // TODO: Get from current user context
                transaction: _dapperDataContext.Transaction,
                commandType: CommandType.StoredProcedure,
                commandTimeout: conn.ConnectionTimeout
            ).ConfigureAwait(false);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var conn = _dapperDataContext.Connection ?? throw new InvalidOperationException("Database connection is not available.");

            var exists = await conn.ExecuteScalarAsync<bool>(
                sql: "CheckSiteExists",
                param: new { Id = id },
                transaction: _dapperDataContext.Transaction,
                commandType: CommandType.StoredProcedure,
                commandTimeout: conn.ConnectionTimeout
            ).ConfigureAwait(false);

            return exists;
        }

        public async Task<bool> ReferenceNumberExistsAsync(string referenceNumber, int? excludeId = null)
        {
            var conn = _dapperDataContext.Connection ?? throw new InvalidOperationException("Database connection is not available.");

            var exists = await conn.ExecuteScalarAsync<bool>(
                sql: "CheckSiteReferenceNumberExists",
                param: new { ReferenceNumber = referenceNumber, ExcludeId = excludeId },
                transaction: _dapperDataContext.Transaction,
                commandType: CommandType.StoredProcedure,
                commandTimeout: conn.ConnectionTimeout
            ).ConfigureAwait(false);

            return exists;
        }
    }
}

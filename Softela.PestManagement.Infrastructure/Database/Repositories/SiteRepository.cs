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
            parameters.Add("@AccountId", site.AccountId);
            parameters.Add("@AddressId", site.AddressId);
            parameters.Add("@PrimaryContactId", site.PrimaryContactId);
            parameters.Add("@PropertyType", site.PropertyType);
            parameters.Add("@Notes", site.Notes);
            parameters.Add("@Latitude", site.Latitude);
            parameters.Add("@Longitude", site.Longitude);
            parameters.Add("@Instructions", site.Instructions);
            parameters.Add("@TaxTypeId", site.TaxTypeId);
            parameters.Add("@SalesPersonId", site.SalesPersonId);
            parameters.Add("@SiteReferenceNumber", site.SiteReferenceNumber);
            parameters.Add("@SendCompletedWoMethod", site.SendCompletedWoMethod);
            parameters.Add("@SendCompletedWoTo", site.SendCompletedWoTo);
            parameters.Add("@Facility", site.Facility);
            parameters.Add("@FacilityType", site.FacilityType);
            parameters.Add("@SiteManagerId", site.SiteManagerId);
            parameters.Add("@IsDeleted", site.IsDeleted);
            parameters.Add("@CreatedBy", site.CreatedBy);
            parameters.Add("@LastChangedBy", site.LastChangedBy);

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

        public async Task<List<Site>> GetByAccountIdAsync(int accountId)
        {
            var conn = _dapperDataContext.Connection ?? throw new InvalidOperationException("Database connection is not available.");

            var sites = await conn.QueryAsync<Site>(
                sql: "GetSitesByAccountId",
                param: new { AccountId = accountId },
                transaction: _dapperDataContext.Transaction,
                commandType: CommandType.StoredProcedure,
                commandTimeout: conn.ConnectionTimeout
            ).ConfigureAwait(false);

            return sites.ToList();
        }

        public async Task<List<Site>> GetAllAsync()
        {
            var conn = _dapperDataContext.Connection ?? throw new InvalidOperationException("Database connection is not available.");

            var sites = await conn.QueryAsync<Site>(
                sql: "GetAllSites",
                transaction: _dapperDataContext.Transaction,
                commandType: CommandType.StoredProcedure,
                commandTimeout: conn.ConnectionTimeout
            ).ConfigureAwait(false);

            return sites.ToList();
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

        public async Task DeleteAsync(int id)
        {
            var conn = _dapperDataContext.Connection ?? throw new InvalidOperationException("Database connection is not available.");

            await conn.ExecuteAsync(
                sql: "DeleteSite",
                param: new { Id = id },
                transaction: _dapperDataContext.Transaction,
                commandType: CommandType.StoredProcedure,
                commandTimeout: conn.ConnectionTimeout
            ).ConfigureAwait(false);
        }
    }
}

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
    public class SiteRepository : ISiteRepository
    {
        private readonly IDapperDataContext _dapperDataContext;

        public SiteRepository(IDapperDataContext dapperDataContext)
        {
            _dapperDataContext = dapperDataContext;
        }

        public async Task CreateUpdateSiteAsync(Site site)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ReferenceNumber", site.ReferenceNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("@AccountId", site.AccountId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Id", site.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@CreatedAt", site.CreatedAt, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@ModifiedAt", site.ModifiedAt, DbType.DateTime, ParameterDirection.Input);

            await _dapperDataContext.Connection!.QueryAsync
            (
                sql: "UpsertSite",
                param: parameters,
                commandType: CommandType.StoredProcedure,
                transaction: _dapperDataContext.Transaction,
                commandTimeout: _dapperDataContext.Connection!.ConnectionTimeout
            ).ConfigureAwait(false);
        }

        public void DeleteSite(int id)
        {
            throw new NotImplementedException();
        }

        public Site GetSiteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Site>> GetSitesAsync()
        {
            var sites = await _dapperDataContext.Connection!
                .QueryAsync<Site>(
                    sql: "GetSites",
                    param: null,
                    commandType: CommandType.StoredProcedure,
                    transaction: _dapperDataContext.Transaction,
                    commandTimeout: _dapperDataContext.Connection!.ConnectionTimeout
                );
            return sites.ToList();
        }
    }
}

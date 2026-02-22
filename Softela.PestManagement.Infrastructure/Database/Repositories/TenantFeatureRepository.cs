using System.Data;
using Dapper;
using Softela.PestManagement.Application.Repositories;
using Softela.PestManagement.Domain.Entities;
using Softela.PestManagement.Infrastructure.Database.Dapper;

namespace Softela.PestManagement.Infrastructure.Database.Repositories;

public class TenantFeatureRepository : ITenantFeatureRepository
{
    private readonly IDapperDataContext _dapperDataContext;

    public TenantFeatureRepository(IDapperDataContext dapperDataContext)
    {
        _dapperDataContext = dapperDataContext;
    }

    public async Task UpsertAsync(TenantFeature feature)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@TenantId", feature.TenantId, DbType.Int32);
        parameters.Add("@FeatureKey", feature.FeatureKey, DbType.String);
        parameters.Add("@IsEnabled", feature.IsEnabled, DbType.Boolean);
        parameters.Add("@CreatedAt", feature.CreatedAt, DbType.DateTime2);
        parameters.Add("@ModifiedAt", feature.ModifiedAt, DbType.DateTime2);

        await _dapperDataContext.Connection!.ExecuteAsync(
            sql: "UpsertTenantFeature",
            param: parameters,
            commandType: CommandType.StoredProcedure,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task<List<TenantFeature>> GetByTenantIdAsync(int tenantId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@TenantId", tenantId, DbType.Int32);

        var features = await _dapperDataContext.Connection!.QueryAsync<TenantFeature>(
            sql: "GetTenantFeatures",
            param: parameters,
            commandType: CommandType.StoredProcedure,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);

        return features.ToList();
    }

    public async Task<bool> IsEnabledAsync(int tenantId, string key)
    {
        var features = await GetByTenantIdAsync(tenantId);
        var feature = features.FirstOrDefault(f => f.FeatureKey == key);
        return feature?.IsEnabled ?? false;
    }
}

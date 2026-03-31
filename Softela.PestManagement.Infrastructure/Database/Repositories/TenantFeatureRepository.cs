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
        parameters.Add("p_tenant_id", feature.TenantId, DbType.Int32);
        parameters.Add("p_feature_key", feature.FeatureKey, DbType.String);
        parameters.Add("p_is_enabled", feature.IsEnabled, DbType.Boolean);
        parameters.Add("p_created_at", feature.CreatedAt, DbType.DateTimeOffset);
        parameters.Add("p_modified_at", feature.ModifiedAt, DbType.DateTimeOffset);

        await _dapperDataContext.Connection!.ExecuteAsync(
            sql: "CALL UpsertTenantFeature(@p_tenant_id, @p_feature_key, @p_is_enabled, @p_created_at, @p_modified_at)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task<List<TenantFeature>> GetByTenantIdAsync(int tenantId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@TenantId", tenantId, DbType.Int32);

        var features = await _dapperDataContext.Connection!.QueryAsync<TenantFeature>(
            sql: "SELECT * FROM get_tenant_features(@TenantId)",
            param: parameters,
            commandType: CommandType.Text,
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

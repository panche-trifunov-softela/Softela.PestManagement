using System.Data;
using Dapper;
using Softela.PestManagement.Application.Repositories;
using Softela.PestManagement.Domain.Entities;
using Softela.PestManagement.Infrastructure.Database.Dapper;

namespace Softela.PestManagement.Infrastructure.Database.Repositories;

public class CfgCadenceRepository : ICfgCadenceRepository
{
    private readonly IDapperDataContext _dapperDataContext;

    public CfgCadenceRepository(IDapperDataContext dapperDataContext)
    {
        _dapperDataContext = dapperDataContext;
    }

    public async Task<int> CreateAsync(CfgCadence cfgCadence)
    {
        var parameters = new DynamicParameters();
        parameters.Add("p_tenant_id", cfgCadence.TenantId, DbType.Int32);
        parameters.Add("p_name", cfgCadence.Name, DbType.String);
        parameters.Add("p_created_at", cfgCadence.CreatedAt, DbType.DateTimeOffset);
        parameters.Add("p_modified_at", cfgCadence.ModifiedAt, DbType.DateTimeOffset);
        parameters.Add("p_created_by", cfgCadence.CreatedBy, DbType.Guid);
        parameters.Add("p_modified_by", cfgCadence.ModifiedBy, DbType.Guid);

        return await _dapperDataContext.Connection!.QuerySingleAsync<int>(
            sql: "SELECT insert_cfg_cadence(@p_tenant_id, @p_name, @p_created_at, @p_modified_at, @p_created_by, @p_modified_by)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task<int> UpdateAsync(CfgCadence cfgCadence)
    {
        var parameters = new DynamicParameters();
        parameters.Add("p_id", cfgCadence.Id, DbType.Int32);
        parameters.Add("p_tenant_id", cfgCadence.TenantId, DbType.Int32);
        parameters.Add("p_name", cfgCadence.Name, DbType.String);
        parameters.Add("p_modified_at", cfgCadence.ModifiedAt, DbType.DateTimeOffset);
        parameters.Add("p_modified_by", cfgCadence.ModifiedBy, DbType.Guid);

        return await _dapperDataContext.Connection!.QuerySingleAsync<int>(
            sql: "SELECT update_cfg_cadence(@p_id, @p_tenant_id, @p_name, @p_modified_at, @p_modified_by)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task DeleteAsync(int id, int tenantId, DateTimeOffset modifiedAt, Guid modifiedBy)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@Id", id, DbType.Int32);
        parameters.Add("@TenantId", tenantId, DbType.Int32);
        parameters.Add("@ModifiedAt", modifiedAt, DbType.DateTimeOffset);
        parameters.Add("@ModifiedBy", modifiedBy, DbType.Guid);

        await _dapperDataContext.Connection!.ExecuteAsync(
            sql: "SELECT delete_cfg_cadence(@Id, @TenantId, @ModifiedAt, @ModifiedBy)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task<CfgCadence?> GetByIdAsync(int id, int tenantId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@Id", id, DbType.Int32);
        parameters.Add("@TenantId", tenantId, DbType.Int32);

        return await _dapperDataContext.Connection!.QueryFirstOrDefaultAsync<CfgCadence>(
            sql: "SELECT * FROM get_cfg_cadence_by_id(@Id, @TenantId)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task<List<CfgCadence>> GetByTenantIdAsync(int tenantId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@TenantId", tenantId, DbType.Int32);

        var cfgCadences = await _dapperDataContext.Connection!.QueryAsync<CfgCadence>(
            sql: "SELECT * FROM get_cfg_cadences_by_tenant_id(@TenantId)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);

        return cfgCadences.ToList();
    }
}

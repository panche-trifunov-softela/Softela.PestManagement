using System.Data;
using Dapper;
using Softela.PestManagement.Application.Repositories;
using Softela.PestManagement.Domain.Entities;
using Softela.PestManagement.Infrastructure.Database.Dapper;

namespace Softela.PestManagement.Infrastructure.Database.Repositories;

public class CfgProgramEventCadenceRepository : ICfgProgramEventCadenceRepository
{
    private readonly IDapperDataContext _dapperDataContext;

    public CfgProgramEventCadenceRepository(IDapperDataContext dapperDataContext)
    {
        _dapperDataContext = dapperDataContext;
    }

    public async Task<int> CreateAsync(CfgProgramEventCadence cfgProgramEventCadence)
    {
        var parameters = new DynamicParameters();
        parameters.Add("p_tenant_id", cfgProgramEventCadence.TenantId, DbType.Int32);
        parameters.Add("p_cfg_program_id", cfgProgramEventCadence.CfgProgramId, DbType.Int32);
        parameters.Add("p_cfg_event_id", cfgProgramEventCadence.CfgEventId, DbType.Int32);
        parameters.Add("p_cfg_cadence_id", cfgProgramEventCadence.CfgCadenceId, DbType.Int32);
        parameters.Add("p_interval", cfgProgramEventCadence.Interval, DbType.Decimal);
        parameters.Add("p_created_at", cfgProgramEventCadence.CreatedAt, DbType.DateTimeOffset);
        parameters.Add("p_modified_at", cfgProgramEventCadence.ModifiedAt, DbType.DateTimeOffset);
        parameters.Add("p_created_by", cfgProgramEventCadence.CreatedBy, DbType.Guid);
        parameters.Add("p_modified_by", cfgProgramEventCadence.ModifiedBy, DbType.Guid);

        return await _dapperDataContext.Connection!.QuerySingleAsync<int>(
            sql: "SELECT insert_cfg_program_event_cadence(@p_tenant_id, @p_cfg_program_id, @p_cfg_event_id, @p_cfg_cadence_id, @p_interval, @p_created_at, @p_modified_at, @p_created_by, @p_modified_by)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task<int> UpdateAsync(CfgProgramEventCadence cfgProgramEventCadence)
    {
        var parameters = new DynamicParameters();
        parameters.Add("p_id", cfgProgramEventCadence.Id, DbType.Int32);
        parameters.Add("p_tenant_id", cfgProgramEventCadence.TenantId, DbType.Int32);
        parameters.Add("p_cfg_program_id", cfgProgramEventCadence.CfgProgramId, DbType.Int32);
        parameters.Add("p_cfg_event_id", cfgProgramEventCadence.CfgEventId, DbType.Int32);
        parameters.Add("p_cfg_cadence_id", cfgProgramEventCadence.CfgCadenceId, DbType.Int32);
        parameters.Add("p_interval", cfgProgramEventCadence.Interval, DbType.Decimal);
        parameters.Add("p_modified_at", cfgProgramEventCadence.ModifiedAt, DbType.DateTimeOffset);
        parameters.Add("p_modified_by", cfgProgramEventCadence.ModifiedBy, DbType.Guid);

        return await _dapperDataContext.Connection!.QuerySingleAsync<int>(
            sql: "SELECT update_cfg_program_event_cadence(@p_id, @p_tenant_id, @p_cfg_program_id, @p_cfg_event_id, @p_cfg_cadence_id, @p_interval, @p_modified_at, @p_modified_by)",
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
            sql: "SELECT delete_cfg_program_event_cadence(@Id, @TenantId, @ModifiedAt, @ModifiedBy)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task<CfgProgramEventCadence?> GetByIdAsync(int id, int tenantId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@Id", id, DbType.Int32);
        parameters.Add("@TenantId", tenantId, DbType.Int32);

        return await _dapperDataContext.Connection!.QueryFirstOrDefaultAsync<CfgProgramEventCadence>(
            sql: "SELECT * FROM get_cfg_program_event_cadence_by_id(@Id, @TenantId)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task<List<CfgProgramEventCadence>> GetByProgramIdAsync(int cfgProgramId, int tenantId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@CfgProgramId", cfgProgramId, DbType.Int32);
        parameters.Add("@TenantId", tenantId, DbType.Int32);

        var cfgProgramEventCadences = await _dapperDataContext.Connection!.QueryAsync<CfgProgramEventCadence>(
            sql: "SELECT * FROM get_cfg_program_event_cadences_by_program_id(@CfgProgramId, @TenantId)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);

        return cfgProgramEventCadences.ToList();
    }
}

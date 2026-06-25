using System.Data;
using Dapper;
using Softela.PestManagement.Application.Repositories;
using Softela.PestManagement.Domain.Entities;
using Softela.PestManagement.Infrastructure.Database.Dapper;

namespace Softela.PestManagement.Infrastructure.Database.Repositories;

public class CfgProgramRepository : ICfgProgramRepository
{
    private readonly IDapperDataContext _dapperDataContext;

    public CfgProgramRepository(IDapperDataContext dapperDataContext)
    {
        _dapperDataContext = dapperDataContext;
    }

    public async Task<int> CreateAsync(CfgProgram cfgProgram)
    {
        var parameters = new DynamicParameters();
        parameters.Add("p_tenant_id", cfgProgram.TenantId, DbType.Int32);
        parameters.Add("p_name", cfgProgram.Name, DbType.String);
        parameters.Add("p_created_at", cfgProgram.CreatedAt, DbType.DateTimeOffset);
        parameters.Add("p_modified_at", cfgProgram.ModifiedAt, DbType.DateTimeOffset);
        parameters.Add("p_created_by", cfgProgram.CreatedBy, DbType.Guid);
        parameters.Add("p_modified_by", cfgProgram.ModifiedBy, DbType.Guid);

        return await _dapperDataContext.Connection!.QuerySingleAsync<int>(
            sql: "SELECT insert_cfg_program(@p_tenant_id, @p_name, @p_created_at, @p_modified_at, @p_created_by, @p_modified_by)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task<int> UpdateAsync(CfgProgram cfgProgram)
    {
        var parameters = new DynamicParameters();
        parameters.Add("p_id", cfgProgram.Id, DbType.Int32);
        parameters.Add("p_tenant_id", cfgProgram.TenantId, DbType.Int32);
        parameters.Add("p_name", cfgProgram.Name, DbType.String);
        parameters.Add("p_modified_at", cfgProgram.ModifiedAt, DbType.DateTimeOffset);
        parameters.Add("p_modified_by", cfgProgram.ModifiedBy, DbType.Guid);

        return await _dapperDataContext.Connection!.QuerySingleAsync<int>(
            sql: "SELECT update_cfg_program(@p_id, @p_tenant_id, @p_name, @p_modified_at, @p_modified_by)",
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
            sql: "SELECT delete_cfg_program(@Id, @TenantId, @ModifiedAt, @ModifiedBy)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task<CfgProgram?> GetByIdAsync(int id, int tenantId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@Id", id, DbType.Int32);
        parameters.Add("@TenantId", tenantId, DbType.Int32);

        return await _dapperDataContext.Connection!.QueryFirstOrDefaultAsync<CfgProgram>(
            sql: "SELECT * FROM get_cfg_program_by_id(@Id, @TenantId)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task<List<CfgProgram>> GetByTenantIdAsync(int tenantId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@TenantId", tenantId, DbType.Int32);

        var cfgPrograms = await _dapperDataContext.Connection!.QueryAsync<CfgProgram>(
            sql: "SELECT * FROM get_cfg_programs_by_tenant_id(@TenantId)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);

        return cfgPrograms.ToList();
    }
}

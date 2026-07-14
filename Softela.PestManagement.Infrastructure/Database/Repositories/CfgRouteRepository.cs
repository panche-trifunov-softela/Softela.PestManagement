using System.Data;
using Dapper;
using Softela.PestManagement.Application.Repositories;
using Softela.PestManagement.Domain.Entities;
using Softela.PestManagement.Infrastructure.Database.Dapper;

namespace Softela.PestManagement.Infrastructure.Database.Repositories;

public class CfgRouteRepository : ICfgRouteRepository
{
    private readonly IDapperDataContext _dapperDataContext;

    public CfgRouteRepository(IDapperDataContext dapperDataContext)
    {
        _dapperDataContext = dapperDataContext;
    }

    public async Task<int> CreateAsync(CfgRoute cfgRoute)
    {
        var parameters = new DynamicParameters();
        parameters.Add("p_tenant_id", cfgRoute.TenantId, DbType.Int32);
        parameters.Add("p_cfg_employee_id", cfgRoute.CfgEmployeeId, DbType.Int32);
        parameters.Add("p_name", cfgRoute.Name, DbType.String);
        parameters.Add("p_is_active", cfgRoute.IsActive, DbType.Boolean);
        parameters.Add("p_note", cfgRoute.Note, DbType.String);
        parameters.Add("p_created_at", cfgRoute.CreatedAt, DbType.DateTimeOffset);
        parameters.Add("p_modified_at", cfgRoute.ModifiedAt, DbType.DateTimeOffset);
        parameters.Add("p_created_by", cfgRoute.CreatedBy, DbType.Guid);
        parameters.Add("p_modified_by", cfgRoute.ModifiedBy, DbType.Guid);

        return await _dapperDataContext.Connection!.QuerySingleAsync<int>(
            sql: "SELECT insert_cfg_route(@p_tenant_id, @p_cfg_employee_id, @p_name, @p_is_active, @p_note, @p_created_at, @p_modified_at, @p_created_by, @p_modified_by)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task<int> UpdateAsync(CfgRoute cfgRoute)
    {
        var parameters = new DynamicParameters();
        parameters.Add("p_id", cfgRoute.Id, DbType.Int32);
        parameters.Add("p_tenant_id", cfgRoute.TenantId, DbType.Int32);
        parameters.Add("p_cfg_employee_id", cfgRoute.CfgEmployeeId, DbType.Int32);
        parameters.Add("p_name", cfgRoute.Name, DbType.String);
        parameters.Add("p_is_active", cfgRoute.IsActive, DbType.Boolean);
        parameters.Add("p_note", cfgRoute.Note, DbType.String);
        parameters.Add("p_modified_at", cfgRoute.ModifiedAt, DbType.DateTimeOffset);
        parameters.Add("p_modified_by", cfgRoute.ModifiedBy, DbType.Guid);

        return await _dapperDataContext.Connection!.QuerySingleAsync<int>(
            sql: "SELECT update_cfg_route(@p_id, @p_tenant_id, @p_cfg_employee_id, @p_name, @p_is_active, @p_note, @p_modified_at, @p_modified_by)",
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
            sql: "SELECT delete_cfg_route(@Id, @TenantId, @ModifiedAt, @ModifiedBy)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task<CfgRoute?> GetByIdAsync(int id, int tenantId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@Id", id, DbType.Int32);
        parameters.Add("@TenantId", tenantId, DbType.Int32);

        return await _dapperDataContext.Connection!.QueryFirstOrDefaultAsync<CfgRoute>(
            sql: "SELECT * FROM get_cfg_route_by_id(@Id, @TenantId)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task<List<CfgRoute>> GetByEmployeeIdAsync(int cfgEmployeeId, int tenantId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@CfgEmployeeId", cfgEmployeeId, DbType.Int32);
        parameters.Add("@TenantId", tenantId, DbType.Int32);

        var cfgRoutes = await _dapperDataContext.Connection!.QueryAsync<CfgRoute>(
            sql: "SELECT * FROM get_cfg_routes_by_employee_id(@CfgEmployeeId, @TenantId)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);

        return cfgRoutes.ToList();
    }
}

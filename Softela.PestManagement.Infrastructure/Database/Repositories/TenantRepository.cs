using System.Data;
using Dapper;
using Softela.PestManagement.Application.Repositories;
using Softela.PestManagement.Domain.Entities;
using Softela.PestManagement.Infrastructure.Database.Dapper;

namespace Softela.PestManagement.Infrastructure.Database.Repositories;

public class TenantRepository : ITenantRepository
{
    private readonly IDapperDataContext _dapperDataContext;

    public TenantRepository(IDapperDataContext dapperDataContext)
    {
        _dapperDataContext = dapperDataContext;
    }

    public async Task UpsertAsync(Tenant tenant)
    {
        var parameters = new DynamicParameters();
        parameters.Add("p_id", tenant.Id, DbType.Int32);
        parameters.Add("p_name", tenant.Name, DbType.String);
        parameters.Add("p_slug", tenant.Slug, DbType.String);
        parameters.Add("p_is_active", tenant.IsActive, DbType.Boolean);
        parameters.Add("p_created_at", tenant.CreatedAt, DbType.DateTime2);
        parameters.Add("p_modified_at", tenant.ModifiedAt, DbType.DateTime2);
        parameters.Add("p_created_by", tenant.CreatedBy, DbType.Guid);
        parameters.Add("p_modified_by", tenant.ModifiedBy, DbType.Guid);

        await _dapperDataContext.Connection!.ExecuteAsync(
            sql: "SELECT upsert_tenant(@p_id, @p_name, @p_slug, @p_is_active, @p_created_at, @p_modified_at, @p_created_by, @p_modified_by)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task<List<Tenant>> GetAllAsync()
    {
        var tenants = await _dapperDataContext.Connection!.QueryAsync<Tenant>(
            sql: "SELECT * FROM get_tenants()",
            param: null,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);

        return tenants.ToList();
    }

    public async Task<Tenant> GetByIdAsync(int id)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@Id", id, DbType.Int32);

        return await _dapperDataContext.Connection!.QueryFirstOrDefaultAsync<Tenant>(
            sql: "SELECT * FROM get_tenant_by_id(@Id)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }
}

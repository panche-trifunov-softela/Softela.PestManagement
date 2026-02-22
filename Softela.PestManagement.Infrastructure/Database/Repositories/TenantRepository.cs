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
        parameters.Add("@Id", tenant.Id, DbType.Int32);
        parameters.Add("@Name", tenant.Name, DbType.String);
        parameters.Add("@Slug", tenant.Slug, DbType.String);
        parameters.Add("@IsActive", tenant.IsActive, DbType.Boolean);
        parameters.Add("@CreatedAt", tenant.CreatedAt, DbType.DateTime2);
        parameters.Add("@ModifiedAt", tenant.ModifiedAt, DbType.DateTime2);
        parameters.Add("@CreatedBy", tenant.CreatedBy, DbType.Guid);
        parameters.Add("@ModifiedBy", tenant.ModifiedBy, DbType.Guid);

        await _dapperDataContext.Connection!.ExecuteAsync(
            sql: "UpsertTenant",
            param: parameters,
            commandType: CommandType.StoredProcedure,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task<List<Tenant>> GetAllAsync()
    {
        var tenants = await _dapperDataContext.Connection!.QueryAsync<Tenant>(
            sql: "GetTenants",
            param: null,
            commandType: CommandType.StoredProcedure,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);

        return tenants.ToList();
    }

    public async Task<Tenant> GetByIdAsync(int id)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@Id", id, DbType.Int32);

        return await _dapperDataContext.Connection!.QueryFirstOrDefaultAsync<Tenant>(
            sql: "GetTenantById",
            param: parameters,
            commandType: CommandType.StoredProcedure,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }
}

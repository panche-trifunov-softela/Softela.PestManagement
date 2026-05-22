using System.Data;
using Dapper;
using Softela.PestManagement.Application.Repositories;
using Softela.PestManagement.Domain.Entities;
using Softela.PestManagement.Infrastructure.Database.Dapper;

namespace Softela.PestManagement.Infrastructure.Database.Repositories;

public class EstimateRepository : IEstimateRepository
{
    private readonly IDapperDataContext _dapperDataContext;

    public EstimateRepository(IDapperDataContext dapperDataContext)
    {
        _dapperDataContext = dapperDataContext;
    }

    public async Task<int> CreateAsync(Estimate estimate)
    {
        var parameters = new DynamicParameters();
        parameters.Add("p_id", 0, DbType.Int32);
        parameters.Add("p_tenant_id", estimate.TenantId, DbType.Int32);
        parameters.Add("p_service_address_id", estimate.ServiceAddressId, DbType.Int32);
        parameters.Add("p_name", estimate.Name, DbType.String);
        parameters.Add("p_status", (short)estimate.Status, DbType.Int16);
        parameters.Add("p_service_interest", estimate.ServiceInterest, DbType.String);
        parameters.Add("p_assigned_sales_rep", estimate.AssignedSalesRep, DbType.Int32);
        parameters.Add("p_source", (short)estimate.Source, DbType.Int16);
        parameters.Add("p_created_at", estimate.CreatedAt, DbType.DateTimeOffset);
        parameters.Add("p_modified_at", estimate.ModifiedAt, DbType.DateTimeOffset);
        parameters.Add("p_created_by", estimate.CreatedBy, DbType.Guid);
        parameters.Add("p_modified_by", estimate.ModifiedBy, DbType.Guid);

        return await _dapperDataContext.Connection!.QuerySingleAsync<int>(
            sql: "SELECT upsert_estimate(@p_id, @p_tenant_id, @p_service_address_id, @p_name, @p_status, @p_service_interest, @p_assigned_sales_rep, @p_source, @p_created_at, @p_modified_at, @p_created_by, @p_modified_by)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task UpdateAsync(Estimate estimate)
    {
        var parameters = new DynamicParameters();
        parameters.Add("p_id", estimate.Id, DbType.Int32);
        parameters.Add("p_tenant_id", estimate.TenantId, DbType.Int32);
        parameters.Add("p_service_address_id", estimate.ServiceAddressId, DbType.Int32);
        parameters.Add("p_name", estimate.Name, DbType.String);
        parameters.Add("p_status", (short)estimate.Status, DbType.Int16);
        parameters.Add("p_service_interest", estimate.ServiceInterest, DbType.String);
        parameters.Add("p_assigned_sales_rep", estimate.AssignedSalesRep, DbType.Int32);
        parameters.Add("p_source", (short)estimate.Source, DbType.Int16);
        parameters.Add("p_created_at", estimate.CreatedAt, DbType.DateTimeOffset);
        parameters.Add("p_modified_at", estimate.ModifiedAt, DbType.DateTimeOffset);
        parameters.Add("p_created_by", estimate.CreatedBy, DbType.Guid);
        parameters.Add("p_modified_by", estimate.ModifiedBy, DbType.Guid);

        await _dapperDataContext.Connection!.ExecuteAsync(
            sql: "SELECT upsert_estimate(@p_id, @p_tenant_id, @p_service_address_id, @p_name, @p_status, @p_service_interest, @p_assigned_sales_rep, @p_source, @p_created_at, @p_modified_at, @p_created_by, @p_modified_by)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task DeleteAsync(int id, DateTimeOffset modifiedAt, Guid modifiedBy)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@Id", id, DbType.Int32);
        parameters.Add("@ModifiedAt", modifiedAt, DbType.DateTimeOffset);
        parameters.Add("@ModifiedBy", modifiedBy, DbType.Guid);

        await _dapperDataContext.Connection!.ExecuteAsync(
            sql: "SELECT delete_estimate(@Id, @ModifiedAt, @ModifiedBy)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task<List<Estimate>> GetByServiceAddressIdAsync(int serviceAddressId, int tenantId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@ServiceAddressId", serviceAddressId, DbType.Int32);
        parameters.Add("@TenantId", tenantId, DbType.Int32);

        var estimates = await _dapperDataContext.Connection!.QueryAsync<Estimate>(
            sql: "SELECT * FROM get_estimates_by_service_address_id(@ServiceAddressId, @TenantId)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);

        return estimates.ToList();
    }
}

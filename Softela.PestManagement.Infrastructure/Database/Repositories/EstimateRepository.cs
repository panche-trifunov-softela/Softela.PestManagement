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

    public async Task<int> CreateAsync(OpsEstimate estimate)
    {
        var parameters = new DynamicParameters();
        parameters.Add("p_tenant_id", estimate.TenantId, DbType.Int32);
        parameters.Add("p_cfg_estimate_id", estimate.CfgEstimateId, DbType.Int32);
        parameters.Add("p_service_address_id", estimate.ServiceAddressId, DbType.Int32);
        parameters.Add("p_status", (short)estimate.Status, DbType.Int16);
        parameters.Add("p_service_interest", estimate.ServiceInterest, DbType.String);
        parameters.Add("p_assigned_sales_rep", estimate.AssignedSalesRep, DbType.Int32);
        parameters.Add("p_source", (short)estimate.Source, DbType.Int16);
        parameters.Add("p_created_at", estimate.CreatedAt, DbType.DateTimeOffset);
        parameters.Add("p_modified_at", estimate.ModifiedAt, DbType.DateTimeOffset);
        parameters.Add("p_created_by", estimate.CreatedBy, DbType.Guid);
        parameters.Add("p_modified_by", estimate.ModifiedBy, DbType.Guid);

        return await _dapperDataContext.Connection!.QuerySingleAsync<int>(
            sql: "SELECT insert_estimate(@p_tenant_id, @p_cfg_estimate_id, @p_service_address_id, @p_status, @p_service_interest, @p_assigned_sales_rep, @p_source, @p_created_at, @p_modified_at, @p_created_by, @p_modified_by)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task<int> UpdateAsync(OpsEstimate estimate)
    {
        var parameters = new DynamicParameters();
        parameters.Add("p_id", estimate.Id, DbType.Int32);
        parameters.Add("p_tenant_id", estimate.TenantId, DbType.Int32);
        parameters.Add("p_cfg_estimate_id", estimate.CfgEstimateId, DbType.Int32);
        parameters.Add("p_service_address_id", estimate.ServiceAddressId, DbType.Int32);
        parameters.Add("p_status", (short)estimate.Status, DbType.Int16);
        parameters.Add("p_service_interest", estimate.ServiceInterest, DbType.String);
        parameters.Add("p_assigned_sales_rep", estimate.AssignedSalesRep, DbType.Int32);
        parameters.Add("p_source", (short)estimate.Source, DbType.Int16);
        parameters.Add("p_modified_at", estimate.ModifiedAt, DbType.DateTimeOffset);
        parameters.Add("p_modified_by", estimate.ModifiedBy, DbType.Guid);

        return await _dapperDataContext.Connection!.QuerySingleAsync<int>(
            sql: "SELECT update_estimate(@p_id, @p_tenant_id, @p_cfg_estimate_id, @p_service_address_id, @p_status, @p_service_interest, @p_assigned_sales_rep, @p_source, @p_modified_at, @p_modified_by)",
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
            sql: "SELECT delete_estimate(@Id, @TenantId, @ModifiedAt, @ModifiedBy)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task<List<OpsEstimate>> GetByServiceAddressIdAsync(int serviceAddressId, int tenantId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@ServiceAddressId", serviceAddressId, DbType.Int32);
        parameters.Add("@TenantId", tenantId, DbType.Int32);

        var estimates = await _dapperDataContext.Connection!.QueryAsync<OpsEstimate>(
            sql: "SELECT * FROM get_estimates_by_service_address_id(@ServiceAddressId, @TenantId)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);

        return estimates.ToList();
    }
}

using System.Data;
using Dapper;
using Softela.PestManagement.Application.Repositories;
using Softela.PestManagement.Domain.Entities;
using Softela.PestManagement.Infrastructure.Database.Dapper;

namespace Softela.PestManagement.Infrastructure.Database.Repositories;

public class ServiceAddressRepository : IServiceAddressRepository
{
    private readonly IDapperDataContext _dapperDataContext;

    public ServiceAddressRepository(IDapperDataContext dapperDataContext)
    {
        _dapperDataContext = dapperDataContext;
    }

    public async Task<int> CreateAsync(ServiceAddress serviceAddress)
    {
        var parameters = new DynamicParameters();
        parameters.Add("p_id", 0, DbType.Int32);
        parameters.Add("p_tenant_id", serviceAddress.TenantId, DbType.Int32);
        parameters.Add("p_customer_id", serviceAddress.CustomerId, DbType.Int32);
        parameters.Add("p_service_address_name", serviceAddress.ServiceAddressName, DbType.String);
        parameters.Add("p_service_address_type", serviceAddress.ServiceAddressType, DbType.String);
        parameters.Add("p_address", serviceAddress.Address, DbType.String);
        parameters.Add("p_city", serviceAddress.City, DbType.String);
        parameters.Add("p_state", serviceAddress.State, DbType.String);
        parameters.Add("p_zip", serviceAddress.Zip, DbType.String);
        parameters.Add("p_contact_name", serviceAddress.ContactName, DbType.String);
        parameters.Add("p_contact_phone", serviceAddress.ContactPhone, DbType.String);
        parameters.Add("p_contact_email", serviceAddress.ContactEmail, DbType.String);
        parameters.Add("p_is_active", serviceAddress.IsActive, DbType.Boolean);
        parameters.Add("p_created_at", serviceAddress.CreatedAt, DbType.DateTimeOffset);
        parameters.Add("p_modified_at", serviceAddress.ModifiedAt, DbType.DateTimeOffset);
        parameters.Add("p_created_by", serviceAddress.CreatedBy, DbType.Guid);
        parameters.Add("p_modified_by", serviceAddress.ModifiedBy, DbType.Guid);

        return await _dapperDataContext.Connection!.QuerySingleAsync<int>(
            sql: "SELECT upsert_service_address(@p_id, @p_tenant_id, @p_customer_id, @p_service_address_name, @p_service_address_type, @p_address, @p_city, @p_state, @p_zip, @p_contact_name, @p_contact_phone, @p_contact_email, @p_is_active, @p_created_at, @p_modified_at, @p_created_by, @p_modified_by)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task UpdateAsync(ServiceAddress serviceAddress)
    {
        var parameters = new DynamicParameters();
        parameters.Add("p_id", serviceAddress.Id, DbType.Int32);
        parameters.Add("p_tenant_id", serviceAddress.TenantId, DbType.Int32);
        parameters.Add("p_customer_id", serviceAddress.CustomerId, DbType.Int32);
        parameters.Add("p_service_address_name", serviceAddress.ServiceAddressName, DbType.String);
        parameters.Add("p_service_address_type", serviceAddress.ServiceAddressType, DbType.String);
        parameters.Add("p_address", serviceAddress.Address, DbType.String);
        parameters.Add("p_city", serviceAddress.City, DbType.String);
        parameters.Add("p_state", serviceAddress.State, DbType.String);
        parameters.Add("p_zip", serviceAddress.Zip, DbType.String);
        parameters.Add("p_contact_name", serviceAddress.ContactName, DbType.String);
        parameters.Add("p_contact_phone", serviceAddress.ContactPhone, DbType.String);
        parameters.Add("p_contact_email", serviceAddress.ContactEmail, DbType.String);
        parameters.Add("p_is_active", serviceAddress.IsActive, DbType.Boolean);
        parameters.Add("p_created_at", serviceAddress.CreatedAt, DbType.DateTimeOffset);
        parameters.Add("p_modified_at", serviceAddress.ModifiedAt, DbType.DateTimeOffset);
        parameters.Add("p_created_by", serviceAddress.CreatedBy, DbType.Guid);
        parameters.Add("p_modified_by", serviceAddress.ModifiedBy, DbType.Guid);

        await _dapperDataContext.Connection!.ExecuteAsync(
            sql: "SELECT upsert_service_address(@p_id, @p_tenant_id, @p_customer_id, @p_service_address_name, @p_service_address_type, @p_address, @p_city, @p_state, @p_zip, @p_contact_name, @p_contact_phone, @p_contact_email, @p_is_active, @p_created_at, @p_modified_at, @p_created_by, @p_modified_by)",
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
            sql: "SELECT delete_service_address(@Id, @TenantId, @ModifiedAt, @ModifiedBy)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task<ServiceAddress> GetByIdAsync(int id, int tenantId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@Id", id, DbType.Int32);
        parameters.Add("@TenantId", tenantId, DbType.Int32);

        return await _dapperDataContext.Connection!.QueryFirstOrDefaultAsync<ServiceAddress>(
            sql: "SELECT * FROM get_service_address_by_id(@Id, @TenantId)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task<List<ServiceAddress>> GetByCustomerIdAsync(int customerId, int tenantId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@CustomerId", customerId, DbType.Int32);
        parameters.Add("@TenantId", tenantId, DbType.Int32);

        var serviceAddresses = await _dapperDataContext.Connection!.QueryAsync<ServiceAddress>(
            sql: "SELECT * FROM get_service_addresses_by_customer_id(@CustomerId, @TenantId)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);

        return serviceAddresses.ToList();
    }
}

using System.Data;
using Dapper;
using Softela.PestManagement.Application.Repositories;
using Softela.PestManagement.Domain.Entities;
using Softela.PestManagement.Infrastructure.Database.Dapper;

namespace Softela.PestManagement.Infrastructure.Database.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly IDapperDataContext _dapperDataContext;

    public CustomerRepository(IDapperDataContext dapperDataContext)
    {
        _dapperDataContext = dapperDataContext;
    }

    public async Task<int> CreateAsync(Customer customer)
    {
        var parameters = new DynamicParameters();
        parameters.Add("p_id", 0, DbType.Int32);
        parameters.Add("p_tenant_id", customer.TenantId, DbType.Int32);
        parameters.Add("p_customer_num", customer.CustomerNum, DbType.String);
        parameters.Add("p_name", customer.Name, DbType.String);
        parameters.Add("p_customer_type", (int)customer.CustomerType, DbType.Int32);
        parameters.Add("p_is_active", customer.IsActive, DbType.Boolean);
        parameters.Add("p_send_invoice", customer.SendInvoice, DbType.Boolean);
        parameters.Add("p_email_invoice", customer.EmailInvoice, DbType.Boolean);
        parameters.Add("p_instructions", customer.Instructions, DbType.String);
        parameters.Add("p_primary_note", customer.PrimaryNote, DbType.String);
        parameters.Add("p_registration_num", customer.RegistrationNum, DbType.String);
        parameters.Add("p_preferred_contact_method", customer.PreferredContactMethod, DbType.String);
        parameters.Add("p_billing_address_street", customer.BillingAddressStreet, DbType.String);
        parameters.Add("p_billing_address_city", customer.BillingAddressCity, DbType.String);
        parameters.Add("p_billing_address_state", customer.BillingAddressState, DbType.String);
        parameters.Add("p_billing_address_zip", customer.BillingAddressZip, DbType.String);
        parameters.Add("p_created_at", customer.CreatedAt, DbType.DateTimeOffset);
        parameters.Add("p_modified_at", customer.ModifiedAt, DbType.DateTimeOffset);
        parameters.Add("p_created_by", customer.CreatedBy, DbType.Guid);
        parameters.Add("p_modified_by", customer.ModifiedBy, DbType.Guid);

        return await _dapperDataContext.Connection!.QuerySingleAsync<int>(
            sql: "SELECT upsert_customer(@p_id, @p_tenant_id, @p_customer_num, @p_name, @p_customer_type, @p_is_active, @p_send_invoice, @p_email_invoice, @p_instructions, @p_primary_note, @p_registration_num, @p_preferred_contact_method, @p_billing_address_street, @p_billing_address_city, @p_billing_address_state, @p_billing_address_zip, @p_created_at, @p_modified_at, @p_created_by, @p_modified_by)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task UpdateAsync(Customer customer)
    {
        var parameters = new DynamicParameters();
        parameters.Add("p_id", customer.Id, DbType.Int32);
        parameters.Add("p_tenant_id", customer.TenantId, DbType.Int32);
        parameters.Add("p_customer_num", customer.CustomerNum, DbType.String);
        parameters.Add("p_name", customer.Name, DbType.String);
        parameters.Add("p_customer_type", (int)customer.CustomerType, DbType.Int32);
        parameters.Add("p_is_active", customer.IsActive, DbType.Boolean);
        parameters.Add("p_send_invoice", customer.SendInvoice, DbType.Boolean);
        parameters.Add("p_email_invoice", customer.EmailInvoice, DbType.Boolean);
        parameters.Add("p_instructions", customer.Instructions, DbType.String);
        parameters.Add("p_primary_note", customer.PrimaryNote, DbType.String);
        parameters.Add("p_registration_num", customer.RegistrationNum, DbType.String);
        parameters.Add("p_preferred_contact_method", customer.PreferredContactMethod, DbType.String);
        parameters.Add("p_billing_address_street", customer.BillingAddressStreet, DbType.String);
        parameters.Add("p_billing_address_city", customer.BillingAddressCity, DbType.String);
        parameters.Add("p_billing_address_state", customer.BillingAddressState, DbType.String);
        parameters.Add("p_billing_address_zip", customer.BillingAddressZip, DbType.String);
        parameters.Add("p_created_at", customer.CreatedAt, DbType.DateTimeOffset);
        parameters.Add("p_modified_at", customer.ModifiedAt, DbType.DateTimeOffset);
        parameters.Add("p_created_by", customer.CreatedBy, DbType.Guid);
        parameters.Add("p_modified_by", customer.ModifiedBy, DbType.Guid);

        await _dapperDataContext.Connection!.ExecuteAsync(
            sql: "SELECT upsert_customer(@p_id, @p_tenant_id, @p_customer_num, @p_name, @p_customer_type, @p_is_active, @p_send_invoice, @p_email_invoice, @p_instructions, @p_primary_note, @p_registration_num, @p_preferred_contact_method, @p_billing_address_street, @p_billing_address_city, @p_billing_address_state, @p_billing_address_zip, @p_created_at, @p_modified_at, @p_created_by, @p_modified_by)",
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
            sql: "SELECT delete_customer(@Id, @TenantId, @ModifiedAt, @ModifiedBy)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task<Customer> GetByIdAsync(int id, int tenantId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@Id", id, DbType.Int32);
        parameters.Add("@TenantId", tenantId, DbType.Int32);

        return await _dapperDataContext.Connection!.QueryFirstOrDefaultAsync<Customer>(
            sql: "SELECT * FROM get_customer_by_id(@Id, @TenantId)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task<List<Customer>> GetByTenantIdAsync(int tenantId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@TenantId", tenantId, DbType.Int32);

        var customers = await _dapperDataContext.Connection!.QueryAsync<Customer>(
            sql: "SELECT * FROM get_customers_by_tenant_id(@TenantId)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);

        return customers.ToList();
    }
}

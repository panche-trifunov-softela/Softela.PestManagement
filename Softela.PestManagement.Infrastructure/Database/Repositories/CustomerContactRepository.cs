using System.Data;
using Dapper;
using Softela.PestManagement.Application.Repositories;
using Softela.PestManagement.Domain.Entities;
using Softela.PestManagement.Infrastructure.Database.Dapper;

namespace Softela.PestManagement.Infrastructure.Database.Repositories;

public class CustomerContactRepository : ICustomerContactRepository
{
    private readonly IDapperDataContext _dapperDataContext;

    public CustomerContactRepository(IDapperDataContext dapperDataContext)
    {
        _dapperDataContext = dapperDataContext;
    }

    public async Task<int> UpsertAsync(CustomerContact contact)
    {
        var parameters = new DynamicParameters();
        parameters.Add("p_id", contact.Id, DbType.Int32);
        parameters.Add("p_tenant_id", contact.TenantId, DbType.Int32);
        parameters.Add("p_customer_id", contact.CustomerId, DbType.Int32);
        parameters.Add("p_contact_type", contact.ContactType, DbType.String);
        parameters.Add("p_first_name", contact.FirstName, DbType.String);
        parameters.Add("p_middle_name", contact.MiddleName, DbType.String);
        parameters.Add("p_last_name", contact.LastName, DbType.String);
        parameters.Add("p_email", contact.Email, DbType.String);
        parameters.Add("p_alternate_emails", contact.AlternateEmails, DbType.String);
        parameters.Add("p_created_at", contact.CreatedAt, DbType.DateTimeOffset);
        parameters.Add("p_modified_at", contact.ModifiedAt, DbType.DateTimeOffset);
        parameters.Add("p_created_by", contact.CreatedBy, DbType.Guid);
        parameters.Add("p_modified_by", contact.ModifiedBy, DbType.Guid);

        return await _dapperDataContext.Connection!.QuerySingleAsync<int>(
            sql: "CALL UpsertCustomerContact(@p_id, @p_tenant_id, @p_customer_id, @p_contact_type, @p_first_name, @p_middle_name, @p_last_name, @p_email, @p_alternate_emails, @p_created_at, @p_modified_at, @p_created_by, @p_modified_by)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task<List<CustomerContact>> GetByCustomerIdAsync(int customerId, int tenantId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@CustomerId", customerId, DbType.Int32);
        parameters.Add("@TenantId", tenantId, DbType.Int32);

        var contacts = await _dapperDataContext.Connection!.QueryAsync<CustomerContact>(
            sql: "SELECT * FROM CustomerContacts WHERE CustomerId = @CustomerId AND TenantId = @TenantId AND IsDeleted = FALSE",
            param: parameters,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);

        return contacts.ToList();
    }

    public async Task<List<CustomerContactPhone>> GetPhonesByContactIdAsync(int contactId, int tenantId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@CustomerContactId", contactId, DbType.Int32);
        parameters.Add("@TenantId", tenantId, DbType.Int32);
        var phones = await _dapperDataContext.Connection!.QueryAsync<CustomerContactPhone>(
            sql: "SELECT * FROM CustomerContactPhones WHERE CustomerContactId = @CustomerContactId AND TenantId = @TenantId AND IsDeleted = FALSE",
            param: parameters,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);

        return phones.ToList();
    }

    public async Task<int> UpsertPhoneAsync(CustomerContactPhone phone)
    {
        var parameters = new DynamicParameters();
        parameters.Add("p_id", phone.Id, DbType.Int32);
        parameters.Add("p_tenant_id", phone.TenantId, DbType.Int32);
        parameters.Add("p_customer_contact_id", phone.CustomerContactId, DbType.Int32);
        parameters.Add("p_phone_type", phone.PhoneType, DbType.String);
        parameters.Add("p_phone_number", phone.PhoneNumber, DbType.String);
        parameters.Add("p_created_at", phone.CreatedAt, DbType.DateTimeOffset);
        parameters.Add("p_modified_at", phone.ModifiedAt, DbType.DateTimeOffset);

        return await _dapperDataContext.Connection!.QuerySingleAsync<int>(
            sql: "CALL UpsertCustomerContactPhone(@p_id, @p_tenant_id, @p_customer_contact_id, @p_phone_type, @p_phone_number, @p_created_at, @p_modified_at)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task DeletePhonesByContactIdAsync(int contactId, int tenantId, DateTimeOffset modifiedAt, Guid modifiedBy)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@CustomerContactId", contactId, DbType.Int32);
        parameters.Add("@TenantId", tenantId, DbType.Int32);
        parameters.Add("@ModifiedAt", modifiedAt, DbType.DateTimeOffset);
        parameters.Add("@ModifiedBy", modifiedBy, DbType.Guid);
        await _dapperDataContext.Connection!.ExecuteAsync(
            sql: "SELECT delete_customer_contact_phones(@CustomerContactId, @TenantId, @ModifiedAt, @ModifiedBy)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }
}


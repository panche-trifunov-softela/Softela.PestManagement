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
        parameters.Add("@Id", contact.Id, DbType.Int32);
        parameters.Add("@TenantId", contact.TenantId, DbType.Int32);
        parameters.Add("@CustomerId", contact.CustomerId, DbType.Int32);
        parameters.Add("@ContactType", contact.ContactType, DbType.String);
        parameters.Add("@FirstName", contact.FirstName, DbType.String);
        parameters.Add("@MiddleName", contact.MiddleName, DbType.String);
        parameters.Add("@LastName", contact.LastName, DbType.String);
        parameters.Add("@Email", contact.Email, DbType.String);
        parameters.Add("@AlternateEmails", contact.AlternateEmails, DbType.String);
        parameters.Add("@CreatedAt", contact.CreatedAt, DbType.DateTime2);
        parameters.Add("@ModifiedAt", contact.ModifiedAt, DbType.DateTime2);
        parameters.Add("@CreatedBy", contact.CreatedBy, DbType.Guid);
        parameters.Add("@ModifiedBy", contact.ModifiedBy, DbType.Guid);

        var newId = await _dapperDataContext.Connection!.QuerySingleAsync<int>(
            sql: "UpsertCustomerContact",
            param: parameters,
            commandType: CommandType.StoredProcedure,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);

        return newId;
    }

    public async Task<List<CustomerContact>> GetByCustomerIdAsync(int customerId, int tenantId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@CustomerId", customerId, DbType.Int32);
        parameters.Add("@TenantId", tenantId, DbType.Int32);

        var contacts = await _dapperDataContext.Connection!.QueryAsync<CustomerContact>(
            sql: "SELECT * FROM CustomerContacts WHERE CustomerId = @CustomerId AND TenantId = @TenantId AND IsDeleted = 0",
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
            sql: "SELECT * FROM CustomerContactPhones WHERE CustomerContactId = @CustomerContactId AND TenantId = @TenantId AND IsDeleted = 0",
            param: parameters,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);

        return phones.ToList();
    }

    public async Task<int> UpsertPhoneAsync(CustomerContactPhone phone)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@Id", phone.Id, DbType.Int32);
        parameters.Add("@TenantId", phone.TenantId, DbType.Int32);
        parameters.Add("@CustomerContactId", phone.CustomerContactId, DbType.Int32);
        parameters.Add("@PhoneType", phone.PhoneType, DbType.String);
        parameters.Add("@PhoneNumber", phone.PhoneNumber, DbType.String);
        parameters.Add("@CreatedAt", phone.CreatedAt, DbType.DateTime2);
        parameters.Add("@ModifiedAt", phone.ModifiedAt, DbType.DateTime2);

        var newId = await _dapperDataContext.Connection!.QuerySingleAsync<int>(
            sql: "UpsertCustomerContactPhone",
            param: parameters,
            commandType: CommandType.StoredProcedure,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);

        return newId;
    }

    public async Task DeletePhonesByContactIdAsync(int contactId, int tenantId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@CustomerContactId", contactId, DbType.Int32);
        parameters.Add("@TenantId", tenantId, DbType.Int32);

        await _dapperDataContext.Connection!.ExecuteAsync(
            sql: "DeleteCustomerContactPhones",
            param: parameters,
            commandType: CommandType.StoredProcedure,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }
}

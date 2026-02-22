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
        parameters.Add("@Id", 0, DbType.Int32);
        parameters.Add("@TenantId", customer.TenantId, DbType.Int32);
        parameters.Add("@CustomerNum", customer.CustomerNum, DbType.String);
        parameters.Add("@Name", customer.Name, DbType.String);
        parameters.Add("@CustomerType", (int)customer.CustomerType, DbType.Int32);
        parameters.Add("@IsActive", customer.IsActive, DbType.Boolean);
        parameters.Add("@SendInvoice", customer.SendInvoice, DbType.Boolean);
        parameters.Add("@EmailInvoice", customer.EmailInvoice, DbType.Boolean);
        parameters.Add("@Instructions", customer.Instructions, DbType.String);
        parameters.Add("@PrimaryNote", customer.PrimaryNote, DbType.String);
        parameters.Add("@RegistrationNum", customer.RegistrationNum, DbType.String);
        parameters.Add("@PreferredContactMethod", customer.PreferredContactMethod, DbType.String);
        parameters.Add("@BillingAddressStreet", customer.BillingAddressStreet, DbType.String);
        parameters.Add("@BillingAddressCity", customer.BillingAddressCity, DbType.String);
        parameters.Add("@BillingAddressState", customer.BillingAddressState, DbType.String);
        parameters.Add("@BillingAddressZip", customer.BillingAddressZip, DbType.String);
        parameters.Add("@CreatedAt", customer.CreatedAt, DbType.DateTime2);
        parameters.Add("@ModifiedAt", customer.ModifiedAt, DbType.DateTime2);
        parameters.Add("@CreatedBy", customer.CreatedBy, DbType.Guid);
        parameters.Add("@ModifiedBy", customer.ModifiedBy, DbType.Guid);

        var newId = await _dapperDataContext.Connection!.QuerySingleAsync<int>(
            sql: "UpsertCustomer",
            param: parameters,
            commandType: CommandType.StoredProcedure,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);

        return newId;
    }

    public async Task UpdateAsync(Customer customer)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@Id", customer.Id, DbType.Int32);
        parameters.Add("@TenantId", customer.TenantId, DbType.Int32);
        parameters.Add("@CustomerNum", customer.CustomerNum, DbType.String);
        parameters.Add("@Name", customer.Name, DbType.String);
        parameters.Add("@CustomerType", (int)customer.CustomerType, DbType.Int32);
        parameters.Add("@IsActive", customer.IsActive, DbType.Boolean);
        parameters.Add("@SendInvoice", customer.SendInvoice, DbType.Boolean);
        parameters.Add("@EmailInvoice", customer.EmailInvoice, DbType.Boolean);
        parameters.Add("@Instructions", customer.Instructions, DbType.String);
        parameters.Add("@PrimaryNote", customer.PrimaryNote, DbType.String);
        parameters.Add("@RegistrationNum", customer.RegistrationNum, DbType.String);
        parameters.Add("@PreferredContactMethod", customer.PreferredContactMethod, DbType.String);
        parameters.Add("@BillingAddressStreet", customer.BillingAddressStreet, DbType.String);
        parameters.Add("@BillingAddressCity", customer.BillingAddressCity, DbType.String);
        parameters.Add("@BillingAddressState", customer.BillingAddressState, DbType.String);
        parameters.Add("@BillingAddressZip", customer.BillingAddressZip, DbType.String);
        parameters.Add("@CreatedAt", customer.CreatedAt, DbType.DateTime2);
        parameters.Add("@ModifiedAt", customer.ModifiedAt, DbType.DateTime2);
        parameters.Add("@CreatedBy", customer.CreatedBy, DbType.Guid);
        parameters.Add("@ModifiedBy", customer.ModifiedBy, DbType.Guid);

        await _dapperDataContext.Connection!.ExecuteAsync(
            sql: "UpsertCustomer",
            param: parameters,
            commandType: CommandType.StoredProcedure,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task DeleteAsync(int id, int tenantId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@Id", id, DbType.Int32);
        parameters.Add("@TenantId", tenantId, DbType.Int32);

        await _dapperDataContext.Connection!.ExecuteAsync(
            sql: "DeleteCustomer",
            param: parameters,
            commandType: CommandType.StoredProcedure,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task<Customer> GetByIdAsync(int id, int tenantId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@Id", id, DbType.Int32);
        parameters.Add("@TenantId", tenantId, DbType.Int32);

        return await _dapperDataContext.Connection!.QueryFirstOrDefaultAsync<Customer>(
            sql: "GetCustomerById",
            param: parameters,
            commandType: CommandType.StoredProcedure,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task<List<Customer>> GetByTenantIdAsync(int tenantId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@TenantId", tenantId, DbType.Int32);

        var customers = await _dapperDataContext.Connection!.QueryAsync<Customer>(
            sql: "GetCustomersByTenantId",
            param: parameters,
            commandType: CommandType.StoredProcedure,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);

        return customers.ToList();
    }
}

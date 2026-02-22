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
        parameters.Add("@Id", 0, DbType.Int32);
        parameters.Add("@TenantId", serviceAddress.TenantId, DbType.Int32);
        parameters.Add("@CustomerId", serviceAddress.CustomerId, DbType.Int32);
        parameters.Add("@ServiceAddressName", serviceAddress.ServiceAddressName, DbType.String);
        parameters.Add("@ServiceAddressType", serviceAddress.ServiceAddressType, DbType.String);
        parameters.Add("@Address", serviceAddress.Address, DbType.String);
        parameters.Add("@City", serviceAddress.City, DbType.String);
        parameters.Add("@State", serviceAddress.State, DbType.String);
        parameters.Add("@Zip", serviceAddress.Zip, DbType.String);
        parameters.Add("@ContactName", serviceAddress.ContactName, DbType.String);
        parameters.Add("@ContactPhone", serviceAddress.ContactPhone, DbType.String);
        parameters.Add("@ContactEmail", serviceAddress.ContactEmail, DbType.String);
        parameters.Add("@IsActive", serviceAddress.IsActive, DbType.Boolean);
        parameters.Add("@CreatedAt", serviceAddress.CreatedAt, DbType.DateTime2);
        parameters.Add("@ModifiedAt", serviceAddress.ModifiedAt, DbType.DateTime2);
        parameters.Add("@CreatedBy", serviceAddress.CreatedBy, DbType.Guid);
        parameters.Add("@ModifiedBy", serviceAddress.ModifiedBy, DbType.Guid);

        var newId = await _dapperDataContext.Connection!.QuerySingleAsync<int>(
            sql: "UpsertServiceAddress",
            param: parameters,
            commandType: CommandType.StoredProcedure,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);

        return newId;
    }

    public async Task UpdateAsync(ServiceAddress serviceAddress)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@Id", serviceAddress.Id, DbType.Int32);
        parameters.Add("@TenantId", serviceAddress.TenantId, DbType.Int32);
        parameters.Add("@CustomerId", serviceAddress.CustomerId, DbType.Int32);
        parameters.Add("@ServiceAddressName", serviceAddress.ServiceAddressName, DbType.String);
        parameters.Add("@ServiceAddressType", serviceAddress.ServiceAddressType, DbType.String);
        parameters.Add("@Address", serviceAddress.Address, DbType.String);
        parameters.Add("@City", serviceAddress.City, DbType.String);
        parameters.Add("@State", serviceAddress.State, DbType.String);
        parameters.Add("@Zip", serviceAddress.Zip, DbType.String);
        parameters.Add("@ContactName", serviceAddress.ContactName, DbType.String);
        parameters.Add("@ContactPhone", serviceAddress.ContactPhone, DbType.String);
        parameters.Add("@ContactEmail", serviceAddress.ContactEmail, DbType.String);
        parameters.Add("@IsActive", serviceAddress.IsActive, DbType.Boolean);
        parameters.Add("@CreatedAt", serviceAddress.CreatedAt, DbType.DateTime2);
        parameters.Add("@ModifiedAt", serviceAddress.ModifiedAt, DbType.DateTime2);
        parameters.Add("@CreatedBy", serviceAddress.CreatedBy, DbType.Guid);
        parameters.Add("@ModifiedBy", serviceAddress.ModifiedBy, DbType.Guid);

        await _dapperDataContext.Connection!.ExecuteAsync(
            sql: "UpsertServiceAddress",
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
            sql: "DeleteServiceAddress",
            param: parameters,
            commandType: CommandType.StoredProcedure,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task<ServiceAddress> GetByIdAsync(int id, int tenantId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@Id", id, DbType.Int32);
        parameters.Add("@TenantId", tenantId, DbType.Int32);

        return await _dapperDataContext.Connection!.QueryFirstOrDefaultAsync<ServiceAddress>(
            sql: "GetServiceAddressById",
            param: parameters,
            commandType: CommandType.StoredProcedure,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task<List<ServiceAddress>> GetByCustomerIdAsync(int customerId, int tenantId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@CustomerId", customerId, DbType.Int32);
        parameters.Add("@TenantId", tenantId, DbType.Int32);

        var serviceAddresses = await _dapperDataContext.Connection!.QueryAsync<ServiceAddress>(
            sql: "GetServiceAddressesByCustomerId",
            param: parameters,
            commandType: CommandType.StoredProcedure,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);

        return serviceAddresses.ToList();
    }
}

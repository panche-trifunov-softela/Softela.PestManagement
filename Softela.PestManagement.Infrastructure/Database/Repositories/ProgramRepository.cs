using System.Data;
using Dapper;
using Softela.PestManagement.Application.Repositories;
using Softela.PestManagement.Domain.Entities;
using Softela.PestManagement.Infrastructure.Database.Dapper;

namespace Softela.PestManagement.Infrastructure.Database.Repositories;

public class ProgramRepository : IProgramRepository
{
    private readonly IDapperDataContext _dapperDataContext;

    public ProgramRepository(IDapperDataContext dapperDataContext)
    {
        _dapperDataContext = dapperDataContext;
    }

    public async Task<int> CreateAsync(OpsProgram program)
    {
        var parameters = new DynamicParameters();
        parameters.Add("p_tenant_id", program.TenantId, DbType.Int32);
        parameters.Add("p_ops_estimate_id", program.OpsEstimateId, DbType.Int32);
        parameters.Add("p_cfg_program_id", program.CfgProgramId, DbType.Int32);
        parameters.Add("p_status", program.IsActive, DbType.Boolean);
        parameters.Add("p_notes", program.Notes, DbType.String);
        parameters.Add("p_start_date", program.StartDate, DbType.DateTimeOffset);
        parameters.Add("p_end_date", program.EndDate, DbType.DateTimeOffset);
        parameters.Add("p_renewal_date", program.RenewalDate, DbType.DateTimeOffset);
        parameters.Add("p_canceled_date", program.CanceledDate, DbType.DateTimeOffset);
        parameters.Add("p_pending_cancel_date", program.PendingCancelDate, DbType.DateTimeOffset);
        parameters.Add("p_frequency", (short)program.Frequency, DbType.Int16);
        parameters.Add("p_created_at", program.CreatedAt, DbType.DateTimeOffset);
        parameters.Add("p_modified_at", program.ModifiedAt, DbType.DateTimeOffset);
        parameters.Add("p_created_by", program.CreatedBy, DbType.Guid);
        parameters.Add("p_modified_by", program.ModifiedBy, DbType.Guid);

        return await _dapperDataContext.Connection!.QuerySingleAsync<int>(
            sql: "SELECT insert_program(@p_tenant_id, @p_ops_estimate_id, @p_cfg_program_id, @p_status, @p_notes, @p_start_date, @p_end_date, @p_renewal_date, @p_canceled_date, @p_pending_cancel_date, @p_frequency, @p_created_at, @p_modified_at, @p_created_by, @p_modified_by)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task<int> UpdateAsync(OpsProgram program)
    {
        var parameters = new DynamicParameters();
        parameters.Add("p_id", program.Id, DbType.Int32);
        parameters.Add("p_tenant_id", program.TenantId, DbType.Int32);
        parameters.Add("p_ops_estimate_id", program.OpsEstimateId, DbType.Int32);
        parameters.Add("p_cfg_program_id", program.CfgProgramId, DbType.Int32);
        parameters.Add("p_status", program.IsActive, DbType.Boolean);
        parameters.Add("p_notes", program.Notes, DbType.String);
        parameters.Add("p_start_date", program.StartDate, DbType.DateTimeOffset);
        parameters.Add("p_end_date", program.EndDate, DbType.DateTimeOffset);
        parameters.Add("p_renewal_date", program.RenewalDate, DbType.DateTimeOffset);
        parameters.Add("p_canceled_date", program.CanceledDate, DbType.DateTimeOffset);
        parameters.Add("p_pending_cancel_date", program.PendingCancelDate, DbType.DateTimeOffset);
        parameters.Add("p_frequency", (short)program.Frequency, DbType.Int16);
        parameters.Add("p_modified_at", program.ModifiedAt, DbType.DateTimeOffset);
        parameters.Add("p_modified_by", program.ModifiedBy, DbType.Guid);

        return await _dapperDataContext.Connection!.QuerySingleAsync<int>(
            sql: "SELECT update_program(@p_id, @p_tenant_id, @p_ops_estimate_id, @p_cfg_program_id, @p_status, @p_notes, @p_start_date, @p_end_date, @p_renewal_date, @p_canceled_date, @p_pending_cancel_date, @p_frequency, @p_modified_at, @p_modified_by)",
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
            sql: "SELECT delete_program(@Id, @TenantId, @ModifiedAt, @ModifiedBy)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task<OpsProgram?> GetByIdAsync(int id, int tenantId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@Id", id, DbType.Int32);
        parameters.Add("@TenantId", tenantId, DbType.Int32);

        return await _dapperDataContext.Connection!.QueryFirstOrDefaultAsync<OpsProgram>(
            sql: "SELECT * FROM get_program_by_id(@Id, @TenantId)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task<List<OpsProgram>> GetByEstimateIdAsync(int estimateId, int tenantId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@EstimateId", estimateId, DbType.Int32);
        parameters.Add("@TenantId", tenantId, DbType.Int32);

        var programs = await _dapperDataContext.Connection!.QueryAsync<OpsProgram>(
            sql: "SELECT * FROM get_programs_by_estimate_id(@EstimateId, @TenantId)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);

        return programs.ToList();
    }
}

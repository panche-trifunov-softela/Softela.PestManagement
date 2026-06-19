namespace Softela.PestManagement.Application.Commands.Program.UpdateProgram;

public static class UpdateProgramMapper
{
    public static Domain.Entities.OpsProgram ToDomainEntity(UpdateProgramRequest request, DateTimeOffset now, Guid userId, int tenantId)
    {
        return new Domain.Entities.OpsProgram
        {
            Id = request.Id,
            OpsEstimateId = request.EstimateId,
            CfgProgramId = request.CfgProgramId,
            IsActive = request.Status,
            Notes = request.Notes,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            RenewalDate = request.RenewalDate,
            CanceledDate = request.CanceledDate,
            PendingCancelDate = request.PendingCancelDate,
            Frequency = request.Frequency,
            ModifiedAt = now,
            ModifiedBy = userId,
            TenantId = tenantId
        };
    }
}

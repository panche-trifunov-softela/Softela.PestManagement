namespace Softela.PestManagement.Application.Commands.Program.CreateProgram;

public static class CreateProgramMapper
{
    public static Domain.Entities.OpsProgram ToDomainEntity(CreateProgramRequest request, DateTimeOffset now, Guid userId, int tenantId)
    {
        return new Domain.Entities.OpsProgram
        {
            OpsEstimateId = request.EstimateId,
            IsActive = request.Status,
            Notes = request.Notes,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            RenewalDate = request.RenewalDate,
            Frequency = request.Frequency,
            CanceledDate = null,
            PendingCancelDate = null,
            CreatedAt = now,
            ModifiedAt = now,
            CreatedBy = userId,
            ModifiedBy = userId,
            TenantId = tenantId
        };
    }
}

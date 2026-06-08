namespace Softela.PestManagement.Application.Commands.Program.CreateProgram;

public static class CreateProgramMapper
{
    public static Domain.Entities.Program ToDomainEntity(CreateProgramRequest request, DateTimeOffset now, Guid userId)
    {
        return new Domain.Entities.Program
        {
            EstimateId = request.EstimateId,
            Name = request.Name,
            Status = request.Status,
            Notes = request.Notes,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            RenewalDate = request.RenewalDate,
            Frequency = request.Frequency,
            CanceledDate = DateTimeOffset.MinValue,
            PendingCancelDate = DateTimeOffset.MinValue,
            CreatedAt = now,
            ModifiedAt = now,
            CreatedBy = userId,
            ModifiedBy = userId
        };
    }
}

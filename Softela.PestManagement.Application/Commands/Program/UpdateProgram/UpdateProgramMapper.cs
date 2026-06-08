namespace Softela.PestManagement.Application.Commands.Program.UpdateProgram;

public static class UpdateProgramMapper
{
    public static Domain.Entities.Program ToDomainEntity(UpdateProgramRequest request, DateTimeOffset now, Guid userId)
    {
        return new Domain.Entities.Program
        {
            Id = request.Id,
            Name = request.Name,
            Status = request.Status,
            Notes = request.Notes,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            RenewalDate = request.RenewalDate,
            CanceledDate = request.CanceledDate,
            PendingCancelDate = request.PendingCancelDate,
            Frequency = request.Frequency,
            ModifiedAt = now,
            ModifiedBy = userId
        };
    }
}

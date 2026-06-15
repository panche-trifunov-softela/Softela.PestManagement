using Softela.PestManagement.Application.Dtos;

namespace Softela.PestManagement.Application.Queries.Program.GetPrograms;

public static class GetProgramsMapper
{
    public static ProgramDto ToDto(Domain.Entities.OpsProgram program)
    {
        return new ProgramDto
        {
            Id = program.Id,
            OpsEstimateId = program.OpsEstimateId,
            CfgProgramId = program.CfgProgramId,
            Status = program.IsActive,
            Notes = program.Notes,
            StartDate = program.StartDate,
            EndDate = program.EndDate,
            RenewalDate = program.RenewalDate,
            CanceledDate = program.CanceledDate,
            PendingCancelDate = program.PendingCancelDate,
            Frequency = program.Frequency,
            CreatedAt = program.CreatedAt,
            ModifiedAt = program.ModifiedAt
        };
    }
}

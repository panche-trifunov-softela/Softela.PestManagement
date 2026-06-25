using Softela.PestManagement.Application.Dtos;

namespace Softela.PestManagement.Application.Queries.CfgProgram.GetCfgProgramById;

public static class GetCfgProgramByIdMapper
{
    public static CfgProgramDto ToDto(Domain.Entities.CfgProgram cfgProgram)
    {
        return new CfgProgramDto
        {
            Id = cfgProgram.Id,
            Name = cfgProgram.Name,
            CreatedAt = cfgProgram.CreatedAt,
            ModifiedAt = cfgProgram.ModifiedAt
        };
    }
}

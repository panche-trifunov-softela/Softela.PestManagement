using Softela.PestManagement.Application.Dtos;

namespace Softela.PestManagement.Application.Queries.CfgProgram.GetCfgPrograms;

public static class GetCfgProgramsMapper
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

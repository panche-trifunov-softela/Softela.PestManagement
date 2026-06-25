using Softela.PestManagement.Application.Dtos;

namespace Softela.PestManagement.Application.Queries.CfgCadence.GetCfgCadences;

public static class GetCfgCadencesMapper
{
    public static CfgCadenceDto ToDto(Domain.Entities.CfgCadence cfgCadence)
    {
        return new CfgCadenceDto
        {
            Id = cfgCadence.Id,
            Name = cfgCadence.Name,
            CreatedAt = cfgCadence.CreatedAt,
            ModifiedAt = cfgCadence.ModifiedAt
        };
    }
}

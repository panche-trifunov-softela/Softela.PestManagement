using Softela.PestManagement.Application.Dtos;

namespace Softela.PestManagement.Application.Queries.CfgProgramEventCadence.GetCfgProgramEventCadenceById;

public static class GetCfgProgramEventCadenceByIdMapper
{
    public static CfgProgramEventCadenceDto ToDto(Domain.Entities.CfgProgramEventCadence cfgProgramEventCadence)
    {
        return new CfgProgramEventCadenceDto
        {
            Id = cfgProgramEventCadence.Id,
            CfgProgramId = cfgProgramEventCadence.CfgProgramId,
            CfgEventId = cfgProgramEventCadence.CfgEventId,
            CfgCadenceId = cfgProgramEventCadence.CfgCadenceId,
            Interval = cfgProgramEventCadence.Interval,
            CreatedAt = cfgProgramEventCadence.CreatedAt,
            ModifiedAt = cfgProgramEventCadence.ModifiedAt
        };
    }
}

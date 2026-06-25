using Softela.PestManagement.Application.Dtos;

namespace Softela.PestManagement.Application.Queries.CfgEvent.GetCfgEventById;

public static class GetCfgEventByIdMapper
{
    public static CfgEventDto ToDto(Domain.Entities.CfgEvent cfgEvent)
    {
        return new CfgEventDto
        {
            Id = cfgEvent.Id,
            Name = cfgEvent.Name,
            CreatedAt = cfgEvent.CreatedAt,
            ModifiedAt = cfgEvent.ModifiedAt
        };
    }
}

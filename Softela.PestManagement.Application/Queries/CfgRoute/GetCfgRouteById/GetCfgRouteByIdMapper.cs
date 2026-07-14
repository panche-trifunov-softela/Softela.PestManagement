using Softela.PestManagement.Application.Dtos;

namespace Softela.PestManagement.Application.Queries.CfgRoute.GetCfgRouteById;

public static class GetCfgRouteByIdMapper
{
    public static CfgRouteDto ToDto(Domain.Entities.CfgRoute cfgRoute)
    {
        return new CfgRouteDto
        {
            Id = cfgRoute.Id,
            CfgEmployeeId = cfgRoute.CfgEmployeeId,
            Name = cfgRoute.Name,
            IsActive = cfgRoute.IsActive,
            Note = cfgRoute.Note,
            CreatedAt = cfgRoute.CreatedAt,
            ModifiedAt = cfgRoute.ModifiedAt
        };
    }
}

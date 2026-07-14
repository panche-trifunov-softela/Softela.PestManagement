namespace Softela.PestManagement.Application.Commands.CfgRoute.UpdateCfgRoute;

public static class UpdateCfgRouteMapper
{
    public static Domain.Entities.CfgRoute ToDomainEntity(UpdateCfgRouteRequest request, DateTimeOffset now, Guid userId, int tenantId)
    {
        return new Domain.Entities.CfgRoute
        {
            Id = request.Id,
            CfgEmployeeId = request.CfgEmployeeId,
            Name = request.Name,
            IsActive = request.IsActive,
            Note = request.Note,
            TenantId = tenantId,
            ModifiedAt = now,
            ModifiedBy = userId
        };
    }
}

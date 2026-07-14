namespace Softela.PestManagement.Application.Commands.CfgRoute.CreateCfgRoute;

public static class CreateCfgRouteMapper
{
    public static Domain.Entities.CfgRoute ToDomainEntity(CreateCfgRouteRequest request, DateTimeOffset now, Guid userId, int tenantId)
    {
        return new Domain.Entities.CfgRoute
        {
            CfgEmployeeId = request.CfgEmployeeId,
            Name = request.Name,
            IsActive = request.IsActive,
            Note = request.Note,
            TenantId = tenantId,
            CreatedAt = now,
            ModifiedAt = now,
            CreatedBy = userId,
            ModifiedBy = userId
        };
    }
}

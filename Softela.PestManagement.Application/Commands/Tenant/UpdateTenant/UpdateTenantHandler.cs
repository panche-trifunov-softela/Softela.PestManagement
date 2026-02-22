using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.Tenant.UpdateTenant;

public class UpdateTenantHandler : IRequestHandler<UpdateTenantRequest, bool>
{
    private readonly ITenantRepository _tenantRepository;
    private readonly ITenantContext _tenantContext;

    public UpdateTenantHandler(ITenantRepository tenantRepository, ITenantContext tenantContext)
    {
        _tenantRepository = tenantRepository;
        _tenantContext = tenantContext;
    }

    public async Task<bool> Handle(UpdateTenantRequest request, CancellationToken cancellationToken)
    {
        var existing = await _tenantRepository.GetByIdAsync(request.Id);
        if (existing == null)
            return false;

        var tenant = new Domain.Entities.Tenant
        {
            Id = request.Id,
            Name = request.Name,
            Slug = request.Slug,
            IsActive = request.IsActive,
            CreatedAt = existing.CreatedAt,
            ModifiedAt = DateTime.UtcNow,
            CreatedBy = existing.CreatedBy,
            ModifiedBy = _tenantContext.UserId
        };

        await _tenantRepository.UpsertAsync(tenant);
        return true;
    }
}

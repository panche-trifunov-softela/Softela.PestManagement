using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.Tenant.CreateTenant;

public class CreateTenantHandler : IRequestHandler<CreateTenantRequest, int>
{
    private readonly ITenantRepository _tenantRepository;
    private readonly ITenantContext _tenantContext;

    public CreateTenantHandler(ITenantRepository tenantRepository, ITenantContext tenantContext)
    {
        _tenantRepository = tenantRepository;
        _tenantContext = tenantContext;
    }

    public async Task<int> Handle(CreateTenantRequest request, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;
        var tenant = new Domain.Entities.Tenant
        {
            Id = 0,
            Name = request.Name,
            Slug = request.Slug,
            IsActive = true,
            CreatedAt = now,
            ModifiedAt = now,
            CreatedBy = _tenantContext.UserId,
            ModifiedBy = _tenantContext.UserId
        };

        await _tenantRepository.UpsertAsync(tenant);

        // After upsert, get the newly created tenant by slug to return the id
        var all = await _tenantRepository.GetAllAsync();
        var created = all.FirstOrDefault(t => t.Slug == request.Slug);
        return created?.Id ?? 0;
    }
}

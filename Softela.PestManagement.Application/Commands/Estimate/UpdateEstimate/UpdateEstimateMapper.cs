using System;
using System.Collections.Generic;
using System.Text;

namespace Softela.PestManagement.Application.Commands.Estimate.UpdateEstimate
{
    public static class UpdateEstimateMapper
    {
        public static Domain.Entities.OpsEstimate ToDomainEntity(UpdateEstimateRequest request, DateTimeOffset now, Guid userId, int tenantId)
        {
            return new Domain.Entities.OpsEstimate
            {
                Id = request.Id,
                ServiceAddressId = request.ServiceAddressId,
                Status = request.Status,
                ServiceInterest = request.ServiceInterest,
                AssignedSalesRep = request.AssignedSalesRep,
                Source = request.Source,
                TenantId = tenantId,
                ModifiedAt = now,
                ModifiedBy = userId
            };
        }
    }
}

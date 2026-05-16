using System;
using System.Collections.Generic;
using System.Text;

namespace Softela.PestManagement.Application.Commands.Estimate.CreateEstimate
{
    public static class CreateEstimateMapper
    {
        public static Domain.Entities.Estimate ToDomainEntity(CreateEstimateRequest request, DateTime now, Guid userId)
        {
            return new Domain.Entities.Estimate
            {
                ServiceAddressId = request.ServiceAddressId,
                Name = request.Name,
                Status = request.Status,
                ServiceInterest = request.ServiceInterest,
                AssignedSalesRep = request.AssignedSalesRep,
                Source = request.Source,
                CreatedAt = now,
                ModifiedAt = now,
                CreatedBy = userId,
                ModifiedBy = userId
            };
        }
    }
}

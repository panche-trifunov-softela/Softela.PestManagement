using System;
using System.Collections.Generic;
using System.Text;

namespace Softela.PestManagement.Application.Commands.Estimate.UpdateEstimate
{
    public static class UpdateEstimateMapper
    {
        public static Domain.Entities.Estimate ToDomainEntity(UpdateEstimateRequest request, DateTime now, Guid userId)
        {
            return new Domain.Entities.Estimate
            {
                Id = request.Id,
                ServiceAddressId = request.ServiceAddressId,
                Name = request.Name,
                Status = request.Status,
                ServiceInterest = request.ServiceInterest,
                AssignedSalesRep = request.AssignedSalesRep,
                Source = request.Source,
                ModifiedAt = now,
                ModifiedBy = userId
            };
        }
    }
}

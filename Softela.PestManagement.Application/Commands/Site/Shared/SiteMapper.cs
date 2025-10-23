using Softela.PestManagement.Application.Commands.Site.CreateSite;
using Softela.PestManagement.Application.Commands.Site.UpdateSite;
using SiteEntity = Softela.PestManagement.Domain.Entities.Site;

namespace Softela.PestManagement.Application.Commands.Site.Shared
{
    public static class SiteMapper
    {
        public static SiteEntity ToEntity(this CreateSiteRequest request, Guid? auditUser = null, DateTime? auditUtc = null)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            var now = auditUtc ?? DateTime.UtcNow;
            var user = auditUser ?? Guid.Empty;

            return new SiteEntity
            {
                ReferenceNumber = request.ReferenceNumber ?? string.Empty,
                IsDeleted = 0,
                PropertyType = 0,
                SendCompletedWoMethod = 0,
                SendCompletedWoTo = 0,
                Facility = 0,
                FacilityType = 0,
                Notes = string.Empty,
                Instructions = string.Empty,
                SiteReferenceNumber = string.Empty,
                CreatedAt = now,
                ModifiedAt = now,
                CreatedBy = user,
                ModifiedBy = user
            };
        }

        public static SiteEntity ToEntity(this UpdateSiteRequest request, Guid? auditUser = null, DateTime? createdAt = null, Guid? createdBy = null)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            var now = DateTime.UtcNow;
            var user = auditUser ?? Guid.Empty;
            var created = createdAt ?? now;
            var creator = createdBy ?? user;

            return new SiteEntity
            {
                Id = request.Id,
                ReferenceNumber = request.ReferenceNumber ?? string.Empty,
                IsDeleted = 0,
                PropertyType = 0,
                SendCompletedWoMethod = 0,
                SendCompletedWoTo = 0,
                Facility = 0,
                FacilityType = 0,
                Notes = string.Empty,
                Instructions = string.Empty,
                SiteReferenceNumber = string.Empty,
                CreatedAt = created,
                CreatedBy = creator,
                ModifiedAt = now,
                ModifiedBy = user
            };
        }
    }
}

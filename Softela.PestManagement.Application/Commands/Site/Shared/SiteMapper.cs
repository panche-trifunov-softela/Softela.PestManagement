using Softela.PestManagement.Application.Commands.Site.CreateSite;
using Softela.PestManagement.Application.Commands.Site.UpdateSite;
using SiteEntity = Softela.PestManagement.Domain.Entities.Site;

namespace Softela.PestManagement.Application.Commands.Site.Shared
{
    public static class SiteMapper
    {
        /// <summary>
        /// Map CreateSiteRequest to Site entity
        /// </summary>
        public static SiteEntity ToEntity(this CreateSiteRequest request, string? auditUser = null)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            var user = auditUser ?? "SYSTEM";

            return new SiteEntity
            {
                Id = 0,
                AccountId = request.AccountId,
                AddressId = request.AddressId,
                PrimaryContactId = request.PrimaryContactId,
                PropertyType = request.PropertyType,
                Notes = request.Notes ?? string.Empty,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                Instructions = request.Instructions ?? string.Empty,
                TaxTypeId = request.TaxTypeId,
                SalesPersonId = request.SalesPersonId,
                SiteReferenceNumber = request.SiteReferenceNumber,
                SendCompletedWoMethod = request.SendCompletedWoMethod,
                SendCompletedWoTo = request.SendCompletedWoTo,
                Facility = request.Facility,
                FacilityType = request.FacilityType,
                SiteManagerId = request.SiteManagerId,
                IsDeleted = false,
                UtcTimestamp = DateTime.UtcNow,
                CreatedBy = user,
                UtcLastChanged = DateTime.UtcNow,
                LastChangedBy = user
            };
        }

        /// <summary>
        /// Map UpdateSiteRequest to Site entity
        /// </summary>
        public static SiteEntity ToEntity(this UpdateSiteRequest request, string? auditUser = null)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            var user = auditUser ?? "SYSTEM";

            return new SiteEntity
            {
                Id = request.Id,
                AccountId = request.AccountId,
                AddressId = request.AddressId,
                PrimaryContactId = request.PrimaryContactId,
                PropertyType = request.PropertyType,
                Notes = request.Notes ?? string.Empty,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                Instructions = request.Instructions ?? string.Empty,
                TaxTypeId = request.TaxTypeId,
                SalesPersonId = request.SalesPersonId,
                SiteReferenceNumber = request.SiteReferenceNumber,
                SendCompletedWoMethod = request.SendCompletedWoMethod,
                SendCompletedWoTo = request.SendCompletedWoTo,
                Facility = request.Facility,
                FacilityType = request.FacilityType,
                SiteManagerId = request.SiteManagerId,
                IsDeleted = request.IsDeleted,
                // Note: UtcTimestamp and CreatedBy should not be updated, only set on creation
                UtcLastChanged = DateTime.UtcNow,
                LastChangedBy = user
            };
        }
    }
}

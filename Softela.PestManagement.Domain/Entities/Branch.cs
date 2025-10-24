// Diagram: Branch
namespace Softela.PestManagement.Domain.Entities
{
    public class Branch
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string BranchName { get; set; }
        public string CompanyName { get; set; }
        public int? ContactId { get; set; }
        public int? StreetAddressId { get; set; }
        public int? MailingAddressId { get; set; }
        public bool IsBillingCenter { get; set; }
        public bool IsServiceCenter { get; set; }
        public DateTime UtcTimestamp { get; set; }
        public DateTime UtcLastChanged { get; set; }
        public string LastChangedBy { get; set; }
        public string LicenseNumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? DefaultTaxTypeId { get; set; }
        public string FaxNumber { get; set; }
        public string LicenseNumber1 { get; set; }
    }
}

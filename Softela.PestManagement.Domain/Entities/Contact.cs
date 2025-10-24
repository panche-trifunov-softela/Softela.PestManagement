// Diagram: Contact
namespace Softela.PestManagement.Domain.Entities
{
    public class Contact : BaseEntity
    {
        public int CompanyId { get; set; }
        public byte ContactType { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string WebAddress { get; set; }
        public int? PrimaryPhoneId { get; set; }
        public string BusinessName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? SalutationId { get; set; }
    }
}

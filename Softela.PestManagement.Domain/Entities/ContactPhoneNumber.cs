// Diagram: ContactPhoneNumber
namespace Softela.PestManagement.Domain.Entities
{
    public class ContactPhoneNumber
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public byte PhoneType { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneExtension { get; set; }
        public string PhoneNote { get; set; }
        public DateTime UtcTimestamp { get; set; }
        public DateTime UtcLastChanged { get; set; }
        public string LastChangedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}

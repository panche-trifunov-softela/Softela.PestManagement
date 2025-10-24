// Diagram: ContactPhoneNumber
namespace Softela.PestManagement.Domain.Entities
{
    public class ContactPhoneNumber : BaseEntity
    {
        public int ContactId { get; set; }
        public byte PhoneType { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneExtension { get; set; }
        public string PhoneNote { get; set; }
    }
}

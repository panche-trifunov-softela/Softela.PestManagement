namespace Softela.PestManagement.Domain.Entities
{
    public class Contact : BaseEntity
    {
        public int CompanyId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PhoneExt { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
        public bool IsPrimary { get; set; }
    }
}

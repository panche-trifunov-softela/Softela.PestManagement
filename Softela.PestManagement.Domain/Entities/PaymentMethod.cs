namespace Softela.PestManagement.Domain.Entities
{
    /// <summary>
    /// Lookup table for payment methods (Cash, Check, Credit Card, ACH, etc.)
    /// </summary>
    public class PaymentMethod : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public bool RequiresReference { get; set; } // Requires check number, transaction ID, etc.
        public int SortOrder { get; set; }
    }
}

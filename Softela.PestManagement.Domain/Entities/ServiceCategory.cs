namespace Softela.PestManagement.Domain.Entities
{
    /// <summary>
    /// Lookup table for service categories
    /// </summary>
    public class ServiceCategory : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public int SortOrder { get; set; }
    }
}

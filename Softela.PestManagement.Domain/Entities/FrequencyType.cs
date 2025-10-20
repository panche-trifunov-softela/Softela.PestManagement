namespace Softela.PestManagement.Domain.Entities
{
    /// <summary>
    /// Lookup table for service frequency types (Weekly, Monthly, Quarterly, Annual, etc.)
    /// </summary>
    public class FrequencyType : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int IntervalDays { get; set; } // Number of days between services
        public bool IsActive { get; set; }
        public int SortOrder { get; set; }
    }
}

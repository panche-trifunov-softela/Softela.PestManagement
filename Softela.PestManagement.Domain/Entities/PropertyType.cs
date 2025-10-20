namespace Softela.PestManagement.Domain.Entities
{
    /// <summary>
    /// Lookup table for property types (Residential, Commercial, Industrial, etc.)
    /// </summary>
    public class PropertyType : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public int SortOrder { get; set; }
    }
}

namespace Softela.PestManagement.Domain.Entities
{
    /// <summary>
    /// Lookup table for pest categories (Insects, Rodents, Birds, Wildlife, etc.)
    /// </summary>
    public class PestCategory : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public int SortOrder { get; set; }
    }
}

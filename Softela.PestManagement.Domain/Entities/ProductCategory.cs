namespace Softela.PestManagement.Domain.Entities
{
    /// <summary>
    /// Lookup table for product categories
    /// </summary>
    public class ProductCategory : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int? ParentCategoryId { get; set; } // For hierarchical categories
        public bool IsActive { get; set; }
        public int SortOrder { get; set; }

        // Navigation properties
        public ProductCategory ParentCategory { get; set; }
        public ICollection<ProductCategory> SubCategories { get; set; } = new List<ProductCategory>();
    }
}

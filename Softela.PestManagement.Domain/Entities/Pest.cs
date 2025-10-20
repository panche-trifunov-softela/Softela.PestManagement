namespace Softela.PestManagement.Domain.Entities
{
    public class Pest : BaseEntity
    {
        public string Name { get; set; }
        public string ScientificName { get; set; }
        public string CommonNames { get; set; }
        public int PestCategoryId { get; set; } // Insect, Rodent, Bird, Wildlife, etc.
        public int PestTypeId { get; set; }

        // Description
        public string Description { get; set; }
        public string Identification { get; set; }
        public string LifeCycle { get; set; }
        public string Habitat { get; set; }
        public string Behavior { get; set; }

        // Health and safety
        public string HealthRisks { get; set; }
        public string PropertyDamage { get; set; }
        public bool IsVenomous { get; set; }
        public int SeverityLevel { get; set; } // 1-5 scale

        // Treatment
        public string TreatmentMethods { get; set; }
        public string PreventionTips { get; set; }
        public string RecommendedProducts { get; set; } // JSON or comma-separated product IDs

        // Images and resources
        public string ImageUrl { get; set; }
        public string ResourceLinks { get; set; }

        // Status
        public bool IsActive { get; set; }
        public bool IsRegulated { get; set; } // Protected species, etc.

        // Navigation properties
        public ICollection<WorkOrderPest> WorkOrderPests { get; set; } = new List<WorkOrderPest>();
        public ICollection<WorkOrderProduct> WorkOrderProducts { get; set; } = new List<WorkOrderProduct>();
    }
}

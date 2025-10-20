namespace Softela.PestManagement.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductCategoryId { get; set; }
        public int ProductTypeId { get; set; } // Chemical, Material, Equipment, Service, etc.

        // Chemical-specific (if applicable)
        public string EpaRegistrationNumber { get; set; }
        public string ActiveIngredient { get; set; }
        public decimal? ActiveIngredientPercent { get; set; }
        public string FormulationType { get; set; } // Liquid, Granular, Bait, etc.

        // Application
        public string ApplicationMethod { get; set; }
        public decimal? ApplicationRate { get; set; }
        public string ApplicationRateUnit { get; set; }
        public string TargetPests { get; set; }

        // Inventory
        public string UnitOfMeasure { get; set; }
        public decimal? QuantityOnHand { get; set; }
        public decimal? ReorderPoint { get; set; }
        public decimal? ReorderQuantity { get; set; }

        // Pricing
        public decimal? Cost { get; set; }
        public decimal? Price { get; set; }
        public bool IsTaxable { get; set; }

        // Safety
        public string SafetyDataSheet { get; set; } // URL or file path
        public string Hazards { get; set; }
        public string StorageRequirements { get; set; }
        public string DisposalInstructions { get; set; }

        // Status
        public bool IsActive { get; set; }
        public bool IsRestricted { get; set; }
        public bool RequiresLicense { get; set; }

        // Navigation properties
        public ICollection<WorkOrderProduct> WorkOrderProducts { get; set; } = new List<WorkOrderProduct>();
        public ICollection<InvoiceLineItem> InvoiceLineItems { get; set; } = new List<InvoiceLineItem>();
    }
}

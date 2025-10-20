namespace Softela.PestManagement.Domain.Entities
{
    /// <summary>
    /// Junction table tracking which pests were found/treated in a work order
    /// </summary>
    public class WorkOrderPest : BaseEntity
    {
        public int WorkOrderId { get; set; }
        public int PestId { get; set; }

        // Infestation details
        public int InfestationLevel { get; set; } // 1-5 scale (Low, Moderate, High, Severe, Extreme)
        public string LocationFound { get; set; }
        public int? EstimatedPopulation { get; set; }

        // Evidence
        public bool LivePestsFound { get; set; }
        public bool DeadPestsFound { get; set; }
        public bool EvidenceOfActivity { get; set; } // Droppings, nests, damage, etc.
        public string EvidenceDescription { get; set; }

        // Treatment
        public bool TreatmentApplied { get; set; }
        public string TreatmentDescription { get; set; }
        public string TreatmentAreaDescription { get; set; }

        // Follow-up
        public bool RequiresFollowUp { get; set; }
        public DateTime? RecommendedFollowUpDate { get; set; }

        // Notes
        public string Notes { get; set; }

        // Images
        public string PhotoUrls { get; set; } // JSON array or comma-separated

        // Navigation properties
        public WorkOrder WorkOrder { get; set; }
        public Pest Pest { get; set; }
    }
}

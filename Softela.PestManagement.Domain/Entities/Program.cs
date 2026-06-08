using Softela.PestManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Softela.PestManagement.Domain.Entities
{
    public class Program : TenantScopedEntity
    {
        public string Name { get; set; }
        public bool Status { get; set; }
        public int EstimateId { get; set; }
        public string Notes { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public DateTimeOffset RenewalDate { get; set; }
        public DateTimeOffset CanceledDate { get; set; }
        public DateTimeOffset PendingCancelDate { get; set; }
        public bool IsDeleted { get; set; }
        public ProgramFrequency Frequency { get; set; }
    }
}

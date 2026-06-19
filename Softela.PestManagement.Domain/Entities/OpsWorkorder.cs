using Softela.PestManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Softela.PestManagement.Domain.Entities
{
    public class OpsWorkorder : TenantScopedEntity
    {
        public int OpsEventId { get; set; }

        public required string WorkorderNumber { get; set; }

        public WorkorderStatus Status { get; set; }

        public int RouteId { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public int Duration { get; set; }

        public DateTimeOffset? CompletedDate { get; set; }

        public DateTimeOffset? CanceledDate { get; set; }
    }
}

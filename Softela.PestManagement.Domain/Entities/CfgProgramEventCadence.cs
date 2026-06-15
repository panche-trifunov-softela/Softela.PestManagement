using System;
using System.Collections.Generic;
using System.Text;

namespace Softela.PestManagement.Domain.Entities
{
    public class CfgProgramEventCadence : TenantScopedEntity
    {
        public int CfgProgramId { get; set; }

        public int CfgEventId { get; set; }

        public int CfgCadenceId { get; set; }

        public decimal Interval { get; set; }
    }
}

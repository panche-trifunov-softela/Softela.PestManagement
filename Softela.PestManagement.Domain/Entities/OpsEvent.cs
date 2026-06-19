using System;
using System.Collections.Generic;
using System.Text;

namespace Softela.PestManagement.Domain.Entities
{
    public class OpsEvent : TenantScopedEntity
    {
        public int CfgEventId { get; set; }

        public int OpsProgramId { get; set; }

        public bool IsActive { get; set; }
    }
}

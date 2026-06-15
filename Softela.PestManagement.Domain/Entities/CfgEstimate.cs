using System;
using System.Collections.Generic;
using System.Text;

namespace Softela.PestManagement.Domain.Entities
{
    public class CfgEstimate : TenantScopedEntity
    {
        public required string Name { get; set; }

        public string? Description { get; set; }
    }
}

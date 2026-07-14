using System;
using System.Collections.Generic;
using System.Text;

namespace Softela.PestManagement.Domain.Entities
{
    public class CfgRoute : TenantScopedEntity
    {
        public int CfgEmployeeId { get; set; }

        public required string Name { get; set; }

        public bool IsActive { get; set; }

        public string? Note { get; set; }
    }
}

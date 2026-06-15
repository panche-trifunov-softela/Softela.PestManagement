using System;
using System.Collections.Generic;
using System.Text;

namespace Softela.PestManagement.Domain.Entities
{
    public class CfgCadence : TenantScopedEntity
    {
        public required string Name { get; set; }
    }
}

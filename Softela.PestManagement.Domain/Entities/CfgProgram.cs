using System;
using System.Collections.Generic;
using System.Text;

namespace Softela.PestManagement.Domain.Entities
{
    public class CfgProgram : TenantScopedEntity
    {
        public required string Name { get; set; }
    }
}

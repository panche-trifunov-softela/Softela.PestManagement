using Softela.PestManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Softela.PestManagement.Domain.Entities
{
    public class CfgEmployee : TenantScopedEntity
    {
        public required string Name { get; set; }

        public required string CertificationNumber { get; set; }

        public required string EmployeeNumber { get; set; }

        public EmployeeRole Role { get; set; }

        public bool IsActive { get; set; }
    }
}

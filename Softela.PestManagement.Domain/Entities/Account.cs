using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softela.PestManagement.Domain.Entities
{
    public class Account : BaseEntity
    {
        public string Name { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
    }
}

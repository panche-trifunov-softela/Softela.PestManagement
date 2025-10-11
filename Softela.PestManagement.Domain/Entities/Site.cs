using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softela.PestManagement.Domain.Entities
{
    public class Site : BaseEntity
    {
        public string ReferenceNumber { get; set; }

        public int AccountId { get; set; }

        public bool IsDeleted { get; set; }
    }
}

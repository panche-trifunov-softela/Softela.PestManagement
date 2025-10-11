using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softela.PestManagement.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid ModifiedBy { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}

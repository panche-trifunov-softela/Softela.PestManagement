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

        public DateTimeOffset CreatedAt { get; set; }

        public Guid ModifiedBy { get; set; }

        public DateTimeOffset ModifiedAt { get; set; }
    }
}

using System.Collections.Generic;

namespace Softela.PestManagement.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public List<UserRole> Users { get; set; } = new();
    }
}
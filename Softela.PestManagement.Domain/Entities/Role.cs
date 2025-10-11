using System.Collections.Generic;

namespace Softela.PestManagement.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public List<UserRole> Users { get; set; } = new();
    }
}
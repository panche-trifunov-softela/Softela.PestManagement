using System;
using System.Collections.Generic;

namespace Softela.PestManagement.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public List<UserRole> UserRoles { get; set; } = new();
    }
}
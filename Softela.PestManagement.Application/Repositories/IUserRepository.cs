using Softela.PestManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softela.PestManagement.Application.Repositories
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user);
    }
}

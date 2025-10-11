using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softela.PestManagement.Application.Services.AuthToken
{
    public interface IAuthToken
    {
        string GenerateToken(int userId, string userName, IEnumerable<string> roles);
    }
}

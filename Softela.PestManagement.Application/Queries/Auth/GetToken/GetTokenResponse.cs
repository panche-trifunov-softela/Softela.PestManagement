using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softela.PestManagement.Application.Queries.Auth.GetToken
{
    public class GetTokenResponse
    {
        public bool Success { get; set; }

        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}

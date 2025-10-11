using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softela.PestManagement.Application.Queries.Auth.GetToken
{
    public class GetTokenRequest : IRequest<GetTokenResponse>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}

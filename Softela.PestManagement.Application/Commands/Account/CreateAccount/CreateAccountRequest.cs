using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softela.PestManagement.Application.Commands.Account.CreateAccount
{
    public sealed record CreateAccountRequest : IRequest<bool>
    {
        public string? Name { get; set; }

        public bool IsActive { get; set; }
    }
}

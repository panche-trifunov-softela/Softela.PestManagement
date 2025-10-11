using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softela.PestManagement.Application.Commands.Account.UpdateAccount
{
    public sealed record UpdateAccountRequest : IRequest<bool>
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
    }
}

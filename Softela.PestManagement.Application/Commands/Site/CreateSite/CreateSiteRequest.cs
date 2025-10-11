using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softela.PestManagement.Application.Commands.Site.CreateSite
{
    public sealed record CreateSiteRequest : IRequest<bool>
    {
        public string ReferenceNumber { get; set; }

        public bool IsActive { get; set; }

        public int AccountId { get; set; }
    }
}

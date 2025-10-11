using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softela.PestManagement.Application.Commands.Site.UpdateSite
{
    public class UpdateSiteRequest : IRequest<bool>
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public string ReferenceNumber { get; set; }

        public bool IsActive { get; set; }

        public int AccountId { get; set; }
    }
}

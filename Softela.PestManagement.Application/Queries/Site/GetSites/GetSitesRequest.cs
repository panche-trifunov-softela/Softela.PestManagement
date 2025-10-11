using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softela.PestManagement.Application.Queries.Site.GetSites
{
    public class GetSitesRequest : IRequest<GetSitesResponse>
    {
        public string Search { get; set; }
    }
}

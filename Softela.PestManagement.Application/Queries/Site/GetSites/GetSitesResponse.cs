using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteEntity = Softela.PestManagement.Domain.Entities.Site;

namespace Softela.PestManagement.Application.Queries.Site.GetSites
{
    public class GetSitesResponse
    {
        public List<SiteEntity> Data { get; set; }
    }
}

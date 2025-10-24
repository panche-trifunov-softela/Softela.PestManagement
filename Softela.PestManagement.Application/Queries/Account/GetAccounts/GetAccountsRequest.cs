using MediatR;
using Softela.PestManagement.Application.Queries.Site.GetSites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softela.PestManagement.Application.Queries.Account.GetAccounts
{
    public class GetAccountsRequest : IRequest<GetAccountsResponse>
    {
        public int CompanyId { get; set; }
        public string? SearchTerm { get; set; }
        public short? IsActive { get; set; }
    }
}

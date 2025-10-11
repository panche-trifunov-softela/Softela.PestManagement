using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softela.PestManagement.Application.Core.Query
{
    public interface IQueryDispatcher
    {
        Task<TResponse> QueryAsync<TResponse>(IRequest<TResponse> query, CancellationToken cancellationToken);
    }
}

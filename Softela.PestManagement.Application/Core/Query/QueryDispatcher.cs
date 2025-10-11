using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softela.PestManagement.Application.Core.Query
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IMediator _mediator;

        public QueryDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<TResponse> QueryAsync<TResponse>(IRequest<TResponse> query, CancellationToken cancellationToken)
        {
            return await _mediator.Send(query, cancellationToken).ConfigureAwait(false);
        }
    }
}

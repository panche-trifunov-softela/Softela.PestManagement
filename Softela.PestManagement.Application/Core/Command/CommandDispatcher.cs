using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softela.PestManagement.Application.Core.Command
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IMediator _mediator;

        public CommandDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<TResponse> SendAsync<TResponse, T>(T command, CancellationToken cancellationToken) where T : IRequest<TResponse>
        {
            return await _mediator.Send(command, cancellationToken).ConfigureAwait(false);
        }
    }
}

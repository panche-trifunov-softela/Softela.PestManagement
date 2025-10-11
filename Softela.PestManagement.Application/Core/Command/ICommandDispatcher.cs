using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softela.PestManagement.Application.Core.Command
{
    public interface ICommandDispatcher
    {
        Task<TResponse> SendAsync<TResponse, T>(T command, CancellationToken cancellationToken) where T : IRequest<TResponse>;
    }
}

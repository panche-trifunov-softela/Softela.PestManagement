using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Events;
using Softela.PestManagement.Application.Outbox;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.Program.DeleteProgram;

public class DeleteProgramHandler : IRequestHandler<DeleteProgramRequest, bool>
{
    private readonly IProgramRepository _programRepository;
    private readonly IOutboxRepository _outboxRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantContext _tenantContext;

    public DeleteProgramHandler(
        IProgramRepository programRepository,
        IOutboxRepository outboxRepository,
        IUnitOfWork unitOfWork,
        ITenantContext tenantContext)
    {
        _programRepository = programRepository;
        _outboxRepository = outboxRepository;
        _unitOfWork = unitOfWork;
        _tenantContext = tenantContext;
    }

    public async Task<bool> Handle(DeleteProgramRequest request, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            await _programRepository.DeleteAsync(request.Id, _tenantContext.TenantId, now, _tenantContext.UserId);
            await _outboxRepository.InsertAsync(OutboxMessageFactory.Create(
                new ProgramDeletedEvent(request.Id), now));
            await _unitOfWork.CommitAsync(cancellationToken);
            return true;
        }
        catch
        {
            await _unitOfWork.RollbackAsync(cancellationToken);
            throw;
        }
    }
}

using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Events;
using Softela.PestManagement.Application.Outbox;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.Program.UpdateProgram;

public class UpdateProgramHandler : IRequestHandler<UpdateProgramRequest, bool>
{
    private readonly IProgramRepository _programRepository;
    private readonly IOutboxRepository _outboxRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantContext _tenantContext;

    public UpdateProgramHandler(
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

    public async Task<bool> Handle(UpdateProgramRequest request, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;

        var program = UpdateProgramMapper.ToDomainEntity(request, now, _tenantContext.UserId);
        program.TenantId = _tenantContext.TenantId;

        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            await _programRepository.UpdateAsync(program);
            await _outboxRepository.InsertAsync(OutboxMessageFactory.Create(
                new ProgramUpdatedEvent(program.Id), now));
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

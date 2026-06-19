using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Events;
using Softela.PestManagement.Application.Outbox;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.Program.CreateProgram;

public class CreateProgramHandler : IRequestHandler<CreateProgramRequest, int>
{
    private readonly IProgramRepository _programRepository;
    private readonly IOutboxRepository _outboxRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantContext _tenantContext;

    public CreateProgramHandler(
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

    public async Task<int> Handle(CreateProgramRequest request, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;

        var program = CreateProgramMapper.ToDomainEntity(request, now, _tenantContext.UserId, _tenantContext.TenantId);

        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var id = await _programRepository.CreateAsync(program);
            await _outboxRepository.InsertAsync(
                OutboxMessageFactory.Create(new ProgramCreatedEvent(id, program.OpsEstimateId), now));
            await _unitOfWork.CommitAsync(cancellationToken);
            return id;
        }
        catch
        {
            await _unitOfWork.RollbackAsync(cancellationToken);
            throw;
        }
    }
}

using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Events;
using Softela.PestManagement.Application.Outbox;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.Customer.DeleteCustomer;

public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerRequest, bool>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IOutboxRepository _outboxRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantContext _tenantContext;

    public DeleteCustomerHandler(
        ICustomerRepository customerRepository,
        IOutboxRepository outboxRepository,
        IUnitOfWork unitOfWork,
        ITenantContext tenantContext)
    {
        _customerRepository = customerRepository;
        _outboxRepository = outboxRepository;
        _unitOfWork = unitOfWork;
        _tenantContext = tenantContext;
    }

    public async Task<bool> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            await _customerRepository.DeleteAsync(request.Id, _tenantContext.TenantId, now, _tenantContext.UserId);
            await _outboxRepository.InsertAsync(OutboxMessageFactory.Create(
                new CustomerDeletedEvent(request.Id, _tenantContext.TenantId), now));
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

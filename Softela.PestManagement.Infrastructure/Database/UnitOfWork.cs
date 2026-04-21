using System.Data;
using Softela.PestManagement.Application.Repositories;
using Softela.PestManagement.Infrastructure.Database.Dapper;

namespace Softela.PestManagement.Infrastructure.Database;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly IDapperDataContext _context;

    public UnitOfWork(IDapperDataContext context)
    {
        _context = context;
    }

    public Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_context.Connection!.State != ConnectionState.Open)
            _context.Connection!.Open();
        _context.Transaction = _context.Connection!.BeginTransaction();
        return Task.CompletedTask;
    }

    public Task CommitAsync(CancellationToken cancellationToken = default)
    {
        _context.Transaction!.Commit();
        _context.Transaction.Dispose();
        _context.Transaction = null;
        return Task.CompletedTask;
    }

    public Task RollbackAsync(CancellationToken cancellationToken = default)
    {
        _context.Transaction?.Rollback();
        _context.Transaction?.Dispose();
        _context.Transaction = null;
        return Task.CompletedTask;
    }
}

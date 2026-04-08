using System.Data;
using Softela.PestManagement.Infrastructure.Database.Dapper;

namespace Softela.PestManagement.Infrastructure.Database;

internal static class DapperDataContextExtensions
{
    internal static async Task ExecuteInTransactionAsync(this IDapperDataContext context, Func<Task> action)
    {
        var ownTransaction = context.Transaction is null;
        if (ownTransaction)
        {
            if (context.Connection!.State != ConnectionState.Open)
                context.Connection!.Open();
            context.Transaction = context.Connection!.BeginTransaction();
        }

        try
        {
            await action();
            if (ownTransaction)
            {
                context.Transaction!.Commit();
                context.Transaction = null;
            }
        }
        catch
        {
            if (ownTransaction)
            {
                context.Transaction?.Rollback();
                context.Transaction = null;
            }
            throw;
        }
    }

    internal static async Task<T> ExecuteInTransactionAsync<T>(this IDapperDataContext context, Func<Task<T>> action)
    {
        var ownTransaction = context.Transaction is null;
        if (ownTransaction)
        {
            if (context.Connection!.State != ConnectionState.Open)
                context.Connection!.Open();
            context.Transaction = context.Connection!.BeginTransaction();
        }

        try
        {
            var result = await action();
            if (ownTransaction)
            {
                context.Transaction!.Commit();
                context.Transaction = null;
            }
            return result;
        }
        catch
        {
            if (ownTransaction)
            {
                context.Transaction?.Rollback();
                context.Transaction = null;
            }
            throw;
        }
    }
}

namespace PSL.Infrastructure.Data.UnitOfWork;

public interface IUnitOdWork : IAsyncDisposable
{
    Task<OperationResult.OperationResult> SaveChangeAsync();
}
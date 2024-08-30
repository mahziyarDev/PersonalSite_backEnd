using PSL.Infrastructure.Data.ContextApp;
using PSL.Infrastructure.OperationResult;

namespace PSL.Infrastructure.Data.UnitOfWork;

public class UnitOfWork  : IUnitOdWork
{
    private readonly PSLContext _context;

    /// <summary></summary>
    /// <param name="context"></param>
    public UnitOfWork(PSLContext context)
    {
        _context = context;
    }
    
    public async ValueTask DisposeAsync() => await _context.DisposeAsync();

    public async Task<OperationResult.OperationResult> SaveChangeAsync()
    {
        try
        {
            await _context.SaveChangesAsync();
            await DisposeAsync();
            return new OperationResult.OperationResult(OperationResultCode.DataBase, true,OperationResultMessage.Success);
        }
        catch (Exception e)
        {
            return new OperationResult.OperationResult(OperationResultCode.DataBase, false,e.InnerException.ToString());
        }
    }
}
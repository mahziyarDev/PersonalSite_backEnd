using System.Linq.Expressions;
using PSL.Domain.Entities;
using PSL.Infrastructure.OperationResult;

namespace PSL.Infrastructure.Data.Repository.Base;

public interface IBaseRepository<TEntity,TId> where TEntity : BaseEntity<TId>
{
    IQueryable<TEntity> GetQuery();
    Task<TEntity?> GetByIdAsync(TId entityId);
    Task<List<TEntity>> ListAsync();
    Task<bool> Exists(Expression<Func<TEntity, bool>> expression);
    Task<OperationResult<TEntity>> AddAsync(TEntity entity,int? userId = null);
    Task<OperationResult.OperationResult> AddListAsync(List<TEntity> entities,int? userId=null);
    Task<OperationResult<TEntity>> EditAsync(TEntity entity,int? userId = null);
    Task<OperationResult<TEntity>> DeleteAsync(TEntity entity,int? userId = null);
    Task<OperationResult<TEntity>> DeleteAsync(TId entityId,int? userId = null);
    Task<OperationResult.OperationResult> DeleteListAsync(List<TEntity> entities);
}

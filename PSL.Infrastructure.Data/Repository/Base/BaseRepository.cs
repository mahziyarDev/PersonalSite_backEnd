using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PSL.Domain.Entities;
using PSL.Infrastructure.Data.ContextApp;
using PSL.Infrastructure.OperationResult;

namespace PSL.Infrastructure.Data.Repository.Base;

public class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId> where TEntity : BaseEntity<TId>
    {
        private readonly PSLContext _context;
        private readonly DbSet<TEntity> _dbSet;
        
        public BaseRepository(PSLContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }


        public IQueryable<TEntity> GetQuery()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<TEntity?> GetByIdAsync(TId entityId)
        {
            return await _dbSet.FindAsync(entityId);

        }

        public async Task<List<TEntity>> ListAsync()
        {
            return await _dbSet.Where(x => !x.IsDelete).ToListAsync();
        }
        
        public async Task<bool> Exists(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public async Task<OperationResult<TEntity>> AddAsync(TEntity entity, int? userId = null)
        {
            try
            {
                entity.CreateDate = DateTime.Now;
                var result = await _dbSet.AddAsync(entity);
                return new OperationResult<TEntity>(OperationResultCode.Repository,true,OperationResultMessage.Success,data:result.Entity);
            }
            catch (Exception e)
            {
                return new OperationResult<TEntity>(OperationResultCode.Repository,false,e.InnerException.ToString());
            }
        }

        public async Task<OperationResult.OperationResult> AddListAsync(List<TEntity> entities,  int? userId = null)
        {
            try
            {
                await _context.AddRangeAsync(entities);
                return new OperationResult.OperationResult(OperationResultCode.Repository, true,
                    OperationResultMessage.Success);
            }
            catch (Exception e)
            {
                return new OperationResult.OperationResult(OperationResultCode.Repository, false,
                    OperationResultMessage.Error);
            }
        }

        public async Task<OperationResult<TEntity>> EditAsync(TEntity entity, int? userId = null)
        {
            try
            {
                entity.ModifyDate =DateTime.Now;
                var result = _dbSet.Update(entity);
                return new OperationResult<TEntity>(OperationResultCode.Repository, true,
                    OperationResultMessage.Success, result.Entity);
            }
            catch (Exception e)
            {
                return new OperationResult<TEntity>(OperationResultCode.Repository, false,
                    OperationResultMessage.Error);
            }
        }

        public async Task<OperationResult<TEntity>> DeleteAsync(TEntity entity, int? userId = null)
        {
            try
            {
                entity.DeletedDate = DateTime.Now;
                entity.IsDelete = true;
                var result = _dbSet.Update(entity);
                return new OperationResult<TEntity>(OperationResultCode.Repository, true,
                    OperationResultMessage.Success, result.Entity);
            }
            catch (Exception e)
            {
                return new OperationResult<TEntity>(OperationResultCode.Repository, true,
                    OperationResultMessage.Error);
            }
        }

        public async Task<OperationResult<TEntity>> DeleteAsync(TId entityId,int? userId = null)
        {
            TEntity? entity = await GetByIdAsync(entityId);
            if (entity == null) return new OperationResult<TEntity>(OperationResultCode.Repository, false,
                OperationResultMessage.NotFound);
            var result = await DeleteAsync(entity, userId);
            return new OperationResult<TEntity>(result.Code, result.Success, result.Message, result.Data);
        }

        public async Task<OperationResult.OperationResult> DeleteListAsync(List<TEntity> entities)
        {
            try
            {
                _context.RemoveRange(entities);
                return new OperationResult.OperationResult(OperationResultCode.Repository, true,
                    OperationResultMessage.Success);
            }
            catch (Exception e)
            {
                return new OperationResult.OperationResult(OperationResultCode.Repository, false,
                    OperationResultMessage.Error);
            }
        }
    }
    
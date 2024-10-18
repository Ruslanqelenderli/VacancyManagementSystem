using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VMS.CORE.Helpers;
using VMS.ENTITY.Entities.Common;

namespace VMS.CORE.Abstract.GenericRepository
{
    public interface IRepository<TEntity, TId> : IQuery<TEntity> where TEntity : BaseEntity<TId>
    {
        BaseListResponse<TEntity> Get(List<Expression<Func<TEntity, bool>>>? expression = null,
                             bool enableTracking = true,
                             Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                             PageRequest<TEntity>? request = null,
                             Expression<Func<TEntity, object>> orderExpression = null,
                             Expression<Func<TEntity, object>> orderByDescExpression = null);

        Task<BaseListResponse<TEntity>> GetAsync(List<Expression<Func<TEntity, bool>>>? expression = null,
                            bool enableTracking = true,
                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                            PageRequest<TEntity>? request = null,
                            Expression<Func<TEntity, object>> orderExpression = null,
                            Expression<Func<TEntity, object>> orderByDescExpression = null);

        BaseValueResponse<TEntity> GetById(List<Expression<Func<TEntity, bool>>>? expression = null,
                             bool enableTracking = true,
                             Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                             Expression<Func<TEntity, object>> orderExpression = null,
                             Expression<Func<TEntity, object>> orderByDescExpression = null);

        Task<BaseValueResponse<TEntity>> GetByIdAsync(List<Expression<Func<TEntity, bool>>>? expression = null,
                            bool enableTracking = true,
                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                            Expression<Func<TEntity, object>> orderExpression = null,
                            Expression<Func<TEntity, object>> orderByDescExpression = null);
        BaseValueResponse<TEntity> Add(TEntity entity);
        BaseValueResponse<TEntity> Update(TEntity entity);
        BaseValueResponse<TEntity> DeleteHard(TId id);
        BaseValueResponse<TEntity> DeleteSoft(TId id);
    }
}

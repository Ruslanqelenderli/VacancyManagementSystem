using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VMS.CORE.Helpers;
using VMS.CORE.Abstract.GenericRepository;
using VMS.ENTITY.Entities.Common;
using VMS.CORE.Concrete.EFCore.Context;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Azure.Core;

namespace VMS.CORE.Concrete.EFCore.Repository.GenericRepository
{
    public class EFGenericRepository<TEntity, TContext, TId> : IRepository<TEntity, TId>
    where TId : IEquatable<TId>
    where TEntity : BaseEntity<TId>
    where TContext : DbContext
    {

        protected readonly TContext context;
        public EFGenericRepository(TContext context)
        {
            this.context = context;
        }

        public IQueryable<TEntity> Query()
        {
            return context.Set<TEntity>();
        }

        public BaseValueResponse<TEntity> Add(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Added;
            return new BaseValueResponse<TEntity>(entity);
        }

        public BaseValueResponse<TEntity> DeleteSoft(TId id)
        {
            var entity = Query().FirstOrDefault(x => x.Id.Equals(id));
            if (entity != null)
            {
                entity.IsDeleted = true;
                context.Entry(entity).State = EntityState.Modified;
                return new BaseValueResponse<TEntity>(entity);
            }

            return new BaseValueResponse<TEntity>($"Data not found. Id : {entity.Id}");

        }
        public BaseValueResponse<TEntity> DeleteHard(TId id)
        {
            var entity = Query().FirstOrDefault(x => x.Id.Equals(id));
            if (entity != null)
            {
                context.Entry(entity).State = EntityState.Deleted;
                return new BaseValueResponse<TEntity>(entity);
            }

            return new BaseValueResponse<TEntity>($"Data not found. Id : {entity.Id}");

        }

        public BaseListResponse<TEntity> Get(List<Expression<Func<TEntity, bool>>>? expression = null, bool enableTracking = true, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, PageRequest<TEntity>? request = null, Expression<Func<TEntity, object>> orderExpression = null, Expression<Func<TEntity, object>> orderByDescExpression = null)
        {
            var result = new BaseListResponse<TEntity>();

            var queryable = Query();


            if (expression != null && expression.Count > 0)
            {
                foreach (var exp in expression)
                {
                    queryable = queryable.Where(exp);
                }
            }

            if (!enableTracking) queryable.AsTracking();

            if (include != null) queryable = include(queryable);

            if (request != null) queryable.Skip(request.PageSize * request.CurrentPage - 1)
                                          .Take(request.PageSize);

            if (orderExpression != null) queryable = queryable.OrderBy(orderExpression);

            if (orderByDescExpression != null) queryable = queryable.OrderByDescending(orderByDescExpression);

            result.TotalCount = queryable.Count();

            result.List = queryable.ToList();

            return result;

        }


        public async Task<BaseListResponse<TEntity>> GetAsync(List<Expression<Func<TEntity, bool>>>? expression = null, bool enableTracking = true, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, PageRequest<TEntity>? request = null, Expression<Func<TEntity, object>> orderExpression = null, Expression<Func<TEntity, object>> orderByDescExpression = null)
        {
            var result = new BaseListResponse<TEntity>();

            var queryable = Query();


            if (expression != null && expression.Count > 0)
            {
                foreach (var exp in expression)
                {
                    queryable = queryable.Where(exp);
                }
            }

            if (!enableTracking) queryable.AsTracking();

            if (include != null) queryable = include(queryable);

            if (orderExpression != null) queryable = queryable.OrderBy(orderExpression);

            if (orderByDescExpression != null) queryable = queryable.OrderByDescending(orderByDescExpression);

            result.TotalCount = await queryable.CountAsync();

            if (request != null) queryable = queryable.Skip(request.PageSize * (request.CurrentPage - 1))
                                          .Take(request.PageSize);

            result.List = await queryable.ToListAsync();

            return result;

        }

        public BaseValueResponse<TEntity> Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return new BaseValueResponse<TEntity>(entity);
        }

        public BaseValueResponse<TEntity> GetById(List<Expression<Func<TEntity, bool>>>? expression = null, bool enableTracking = true, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, Expression<Func<TEntity, object>> orderExpression = null, Expression<Func<TEntity, object>> orderByDescExpression = null)
        {
            var queryable = Query();

            if (expression != null && expression.Count > 0)
            {
                foreach (var exp in expression)
                {
                    queryable = queryable.Where(exp);
                }
            }

            if (!enableTracking) queryable.AsTracking();

            if (include != null) queryable = include(queryable);
            if (orderExpression != null) queryable = queryable.OrderBy(orderExpression);

            if (orderByDescExpression != null) queryable = queryable.OrderByDescending(orderByDescExpression);

            return new BaseValueResponse<TEntity>(queryable.FirstOrDefault());
        }

        public async Task<BaseValueResponse<TEntity>> GetByIdAsync(List<Expression<Func<TEntity, bool>>>? expression = null, bool enableTracking = true, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, Expression<Func<TEntity, object>> orderExpression = null, Expression<Func<TEntity, object>> orderByDescExpression = null)
        {
            var queryable = Query();
            if (expression != null && expression.Count > 0)
            {
                foreach (var exp in expression)
                {
                    queryable = queryable.Where(exp);
                }
            }

            if (!enableTracking) queryable.AsTracking();

            if (include != null) queryable = include(queryable);
            if (orderExpression != null) queryable = queryable.OrderBy(orderExpression);

            if (orderByDescExpression != null) queryable = queryable.OrderByDescending(orderByDescExpression);

            return new BaseValueResponse<TEntity>(await queryable.FirstOrDefaultAsync());
        }
    }
}

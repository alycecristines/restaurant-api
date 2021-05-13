using System;
using System.Linq;
using System.Linq.Expressions;

namespace Restaurant.Domain.Extensions
{
    public static class QueryableExtension
    {
        public static IQueryable<TEntity> WhereFor<TEntity>(this IQueryable<TEntity> queryable,
            bool shouldApplyFilter, Expression<Func<TEntity, bool>> expression)
        {
            if (shouldApplyFilter)
            {
                return queryable.Where(expression);
            }

            return queryable;
        }

        public static IQueryable<TEntity> WhereFor<TEntity>(this IQueryable<TEntity> queryable,
            string pattern, Expression<Func<TEntity, bool>> expression)
        {
            if (!string.IsNullOrWhiteSpace(pattern))
            {
                return queryable.Where(expression);
            }

            return queryable;
        }

        public static IQueryable<TEntity> WhereFor<TEntity>(this IQueryable<TEntity> queryable,
            Guid? id, Expression<Func<TEntity, bool>> expression)
        {
            if (id.HasValue)
            {
                return queryable.Where(expression);
            }

            return queryable;
        }
    }
}

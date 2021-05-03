using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant.Core.Entities.Base;
using Restaurant.Core.QueryFilters.Base;

namespace Restaurant.Core.Services.Base
{
    public interface IService<TEntity, TQueryFilter>
        where TEntity : Entity
        where TQueryFilter : QueryFilter
    {
        Task<TEntity> CreateAsync(TEntity newEntity);
        Task<TEntity> UpdateAsync(Guid id, TEntity newEntity);
        Task<TEntity> FindAsync(Guid id);
        Task<IEnumerable<TEntity>> FindAllAsync(TQueryFilter filters);
    }
}

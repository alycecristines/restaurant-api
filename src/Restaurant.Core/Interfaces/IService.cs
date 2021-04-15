using System;
using System.Collections.Generic;
using Restaurant.Core.Common;

namespace Restaurant.Core.Interfaces
{
    public interface IService<TEntity, TQueryFilter>
        where TEntity : Entity
        where TQueryFilter : QueryFilter
    {
        TEntity Create(TEntity newEntity);
        TEntity Update(Guid id, TEntity newEntity);
        TEntity Find(Guid id);
        IEnumerable<TEntity> FindAll(TQueryFilter filters);
    }
}

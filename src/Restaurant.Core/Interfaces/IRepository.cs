using System;
using System.Linq;
using Restaurant.Core.Common;

namespace Restaurant.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        void Add(TEntity entity);
        IQueryable<TEntity> Queryable();
        TEntity Find(Guid id);
        void SaveChanges();
    }
}

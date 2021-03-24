using System;
using System.Linq;
using Restaurant.Core.Common;

namespace Restaurant.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        void Insert(TEntity entity);
        IQueryable<TEntity> GetAll();
        TEntity Get(Guid id);
        void SaveChanges();
    }
}

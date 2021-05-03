using System;
using System.Linq;
using System.Threading.Tasks;
using Restaurant.Core.Entities.Base;

namespace Restaurant.Core.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        void Add(TEntity entity);
        IQueryable<TEntity> Queryable();
        Task<TEntity> FindAsync(Guid id);
        Task SaveChangesAsync();
    }
}

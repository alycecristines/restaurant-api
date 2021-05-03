using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities.Base;
using Restaurant.Core.Repositories.Base;
using Restaurant.Infrastructure.DataContexts;

namespace Restaurant.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        private readonly ApplicationDataContext _dbContext;
        private readonly DbSet<TEntity> _dbEntities;

        public Repository(ApplicationDataContext dbContext)
        {
            _dbContext = dbContext;
            _dbEntities = dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbEntities.Add(entity);
        }

        public async Task<TEntity> FindAsync(Guid id)
        {
            return await _dbEntities.FindAsync(id);
        }

        public IQueryable<TEntity> Queryable()
        {
            return _dbEntities.AsQueryable();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities.Base;
using Restaurant.Core.Interfaces;
using Restaurant.Infrastructure.Data;

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

        public TEntity Find(Guid id)
        {
            return _dbEntities.Find(id);
        }

        public IQueryable<TEntity> Queryable()
        {
            return _dbEntities.AsQueryable();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}

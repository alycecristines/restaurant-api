using Restaurant.Application.Interfaces;
using Restaurant.Core.Common;
using Restaurant.Core.Exceptions;

namespace Restaurant.Application.Validators
{
    public class ServiceValidator : IServiceValidator
    {
        public void Found<TEntity>(TEntity entity) where TEntity : Entity
        {
            if (entity != null) return;

            var typeName = typeof(TEntity).Name;
            var message = $"{typeName} not found.";
            throw new BusinessException(message);
        }

        public void NotDeleted<TEntity>(TEntity entity) where TEntity : Entity
        {
            if (!entity.Deleted) return;

            var typeName = typeof(TEntity).Name;
            var message = $"{typeName} has already been deleted.";
            throw new BusinessException(message);
        }

        public void NotExist<TEntity>(TEntity entity) where TEntity : Entity
        {
            if (entity == null) return;

            var typeName = typeof(TEntity).Name;
            var message = $"{typeName} already exists.";
            throw new BusinessException(message);
        }

        public void HasNoRelated<TEntity>(TEntity entity) where TEntity : Entity
        {
            if (entity == null) return;

            var typeName = typeof(TEntity).Name;
            var message = $"There are active {typeName}s.";
            throw new BusinessException(message);
        }
    }
}

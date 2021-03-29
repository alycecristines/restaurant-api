using Restaurant.Core.Common;

namespace Restaurant.Application.Interfaces
{
    public interface IServiceValidator
    {
        void Found<TEntity>(TEntity entity) where TEntity : Entity;
        void NotDeleted<TEntity>(TEntity entity) where TEntity : Entity;
        void NotExist<TEntity>(TEntity entity) where TEntity : Entity;
        void NotRelated<TEntity>(TEntity entity) where TEntity : Entity;
    }
}

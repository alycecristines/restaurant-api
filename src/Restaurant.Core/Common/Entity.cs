using System;

namespace Restaurant.Core.Common
{
    public class Entity
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        public bool Deleted => DeletedAt.HasValue;
        public bool Inactivated { get; set; }

        public Entity()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public void Update(DateTime updatedAt)
        {
            UpdatedAt = updatedAt;
        }

        public void Delete(DateTime deletedAt)
        {
            DeletedAt = deletedAt;
        }
    }
}

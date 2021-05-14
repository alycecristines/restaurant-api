using System;

namespace Restaurant.Domain.Entities.Base
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; set; }

        public Entity()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}

using System;

namespace Restaurant.Core.Entities.Base
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Inactivated { get; set; }

        public Entity()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}

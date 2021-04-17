using System;

namespace Restaurant.Core.Entities.Base
{
    public class Entity
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool Deleted => DeletedAt.HasValue;
        public bool Inactivated { get; set; }

        public Entity()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}

namespace Restaurant.Domain.Entities.Base
{
    public abstract class ActivableEntity : Entity
    {
        public bool Inactivated { get; set; }
    }
}

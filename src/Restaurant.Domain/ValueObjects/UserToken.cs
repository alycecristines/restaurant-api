using Restaurant.Domain.Entities.Base;

namespace Restaurant.Domain.ValueObjects
{
    public class UserToken
    {
        public User User { get; set; }
        public string Token { get; set; }
    }
}

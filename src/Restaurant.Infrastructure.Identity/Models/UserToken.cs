namespace Restaurant.Infrastructure.Identity.Models
{
    public class UserToken
    {
        public BasicApplicationUser User { get; private set; }
        public string Token { get; private set; }

        public UserToken(BasicApplicationUser user, string token)
        {
            User = user;
            Token = token;
        }
    }
}

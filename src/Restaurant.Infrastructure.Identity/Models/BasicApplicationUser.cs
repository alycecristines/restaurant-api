namespace Restaurant.Infrastructure.Identity.Models
{
    public class BasicApplicationUser
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        public BasicApplicationUser(ApplicationUser user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
        }
    }
}

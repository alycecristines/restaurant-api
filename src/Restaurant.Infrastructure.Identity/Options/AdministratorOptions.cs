namespace Restaurant.Infrastructure.Identity.Options
{
    public class AdministratorOptions
    {
        public string UserName => "Administrator";
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
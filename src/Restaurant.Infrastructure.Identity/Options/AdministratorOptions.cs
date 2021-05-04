namespace Restaurant.Infrastructure.Identity.Options
{
    public class AdministratorOptions
    {
        public const string SectionName = "Administrator";
        public string UserName => "Administrator";
        public string Name { get; set; }
        public string Email { get; set; }
        public string InitialPassword { get; set; }
    }
}

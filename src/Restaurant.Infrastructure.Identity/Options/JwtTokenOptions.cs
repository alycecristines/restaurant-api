namespace Restaurant.Infrastructure.Identity.Options
{
    public class JwtTokenOptions
    {
        public const string SectionName = "JwtToken";
        public string Key { get; set; }
        public double Duration { get; set; }
    }
}

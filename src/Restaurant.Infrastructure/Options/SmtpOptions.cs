namespace Restaurant.Infrastructure.Options
{
    public class SmtpOptions
    {
        public const string SectionName = "Smtp";
        public string Host { get; set; }
        public int Port { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public bool EnableSSL { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Restaurant.Api.Extensions;

namespace Restaurant.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().PrepareDatabases().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).UseSystemd()
                .ConfigureWebHostDefaults(ConfigureWebHost);
        }

        private static void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseStartup<Startup>();
        }
    }
}

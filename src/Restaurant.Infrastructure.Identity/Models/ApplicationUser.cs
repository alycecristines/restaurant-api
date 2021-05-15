using Microsoft.AspNetCore.Identity;

namespace Restaurant.Infrastructure.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}

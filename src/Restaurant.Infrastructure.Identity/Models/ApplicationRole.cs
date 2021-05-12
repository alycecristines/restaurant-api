using Microsoft.AspNetCore.Identity;

namespace Restaurant.Infrastructure.Identity.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() { }
        public ApplicationRole(string roleName) : base(roleName) { }
    }
}

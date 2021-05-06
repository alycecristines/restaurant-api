using System;
using System.Security.Claims;

namespace Restaurant.Api.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static Guid GetId(this ClaimsPrincipal user)
        {
            return new Guid(user.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}

using System.Linq;
using System.Security.Claims;

namespace PhotoGallery.Server.Infrastructure
{
    public static class IdentityExtensions
    {
        public static string GetId(this ClaimsPrincipal user)
        {
            return user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
using Microsoft.AspNetCore.Http;
using PhotoGallery.Server.Infrastructure.Extensions;
using System.Security.Claims;

namespace PhotoGallery.Server.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly ClaimsPrincipal user;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
            => user = httpContextAccessor.HttpContext?.User;

        public string GetUserId()
            => user?.GetId();

        public string GetUserName()
            => user?.Identity?.Name;
    }
}
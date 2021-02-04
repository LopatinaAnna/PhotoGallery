using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoGallery.Server.Features.Profiles.Models;
using PhotoGallery.Server.Infrastructure.Services;
using System.Threading.Tasks;

namespace PhotoGallery.Server.Features.Profiles
{
    public class ProfilesController : ApiController
    {
        private readonly IProfileService profileService;

        private readonly ICurrentUserService currentUser;

        public ProfilesController(
            IProfileService profileService, 
            ICurrentUserService currentUser)
        {
            this.profileService = profileService;
            this.currentUser = currentUser;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ProfileServiceModel>> GetProfile()
            => await profileService.GetProfile(currentUser.GetUserId());
    }
}

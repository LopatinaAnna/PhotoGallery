using Microsoft.EntityFrameworkCore;
using PhotoGallery.Server.Data;
using PhotoGallery.Server.Features.Profiles.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoGallery.Server.Features.Profiles
{
    public class ProfileService : IProfileService
    {
        private readonly ApplicationDbContext data;

        public ProfileService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public async Task<ProfileServiceModel> GetProfile(string userId)
            => await data
                .Users
                .Where(c => c.Id == userId)
                .Select(c => c.Profile)
                .Select(c => new ProfileServiceModel
                {
                    Name = c.Name,
                    ProfilePhotoUrl = c.ProfilePhotoUrl,
                    WebSite = c.WebSite,
                    Biography = c.Biography,
                    Gender = c.Gender.ToString(),
                    IsPrivate = c.IsPrivate
                })
                .FirstOrDefaultAsync();
    }
}

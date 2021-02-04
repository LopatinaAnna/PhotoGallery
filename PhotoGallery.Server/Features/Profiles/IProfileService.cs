using PhotoGallery.Server.Features.Profiles.Models;
using System.Threading.Tasks;

namespace PhotoGallery.Server.Features.Profiles
{
    public interface IProfileService
    {
        Task<ProfileServiceModel> GetProfile(string userId);
    }
}

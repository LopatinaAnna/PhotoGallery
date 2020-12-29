using System.Threading.Tasks;

namespace PhotoGallery.Server.Features.Photos
{
    public interface IPhotoService
    {
        public Task<int> Create(string description, string imageUrl, string userId);
    }
}

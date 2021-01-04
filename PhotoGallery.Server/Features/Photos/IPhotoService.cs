using PhotoGallery.Server.Features.Photos.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoGallery.Server.Features.Photos
{
    public interface IPhotoService
    {
        public Task<int> Create(string description, string imageUrl, string userId);

        public Task<IEnumerable<PhotoListModel>> GetPhotos(string userId);

        public Task<PhotoDetailsModel> GetDetails(int photoId);
    }
}

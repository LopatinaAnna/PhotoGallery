using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoGallery.Server.Features.Photos
{
    public interface IPhotoService
    {
        public Task<int> Create(string description, string imageUrl, string userId);

        public Task<IEnumerable<PhotoListResponseModel>> GetPhotos(string userId);
    }
}

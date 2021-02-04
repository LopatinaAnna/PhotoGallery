using PhotoGallery.Server.Features.Photos.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoGallery.Server.Features.Photos
{
    public interface IPhotoService
    {
        Task<int> Create(string description, string imageUrl, string userId);

        Task<IEnumerable<PhotoListModel>> GetPhotos(string userId);

        Task<PhotoDetailsModel> GetDetails(int photoId);

        Task<bool> Update(int id, string description, string userId);

        Task<bool> Delete(int id, string userId);
    }
}
using Microsoft.EntityFrameworkCore;
using PhotoGallery.Server.Data;
using PhotoGallery.Server.Data.Models;
using PhotoGallery.Server.Features.Photos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoGallery.Server.Features.Photos
{
    public class PhotoService : IPhotoService
    {
        private readonly ApplicationDbContext data;

        public PhotoService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public async Task<int> Create(string description, string imageUrl, string userId)
        {
            var photo = new Photo
            {
                Description = description,
                ImageUrl = imageUrl,
                UserId = userId
            };

            data.Add(photo);

            await data.SaveChangesAsync();

            return photo.Id;
        }

        public async Task<PhotoDetailsModel> GetDetails(int photoId)
        {
            return await data
                .Photos
                .Where(c => c.Id == photoId)
                .Select(c => new PhotoDetailsModel
                {
                    Id = c.Id,
                    Description = c.Description,
                    ImageUrl = c.ImageUrl,
                    UserId = c.UserId,
                    UserName = c.UserId

                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PhotoListModel>> GetPhotos(string userId)
        {
            return await data
                .Photos
                .Where(c => c.UserId == userId)
                .Select(c => new PhotoListModel 
                { 
                    Id = c.Id, 
                    ImageUrl = c.ImageUrl 
                })
                .ToListAsync();
        }
    }
}

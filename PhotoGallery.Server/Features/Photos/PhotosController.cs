using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoGallery.Server.Data;
using PhotoGallery.Server.Data.Models;
using PhotoGallery.Server.Infrastructure;
using System.Threading.Tasks;

namespace PhotoGallery.Server.Features.Photos
{
    public class PhotosController : ApiController
    {
        private readonly ApplicationDbContext data;

        public PhotosController(ApplicationDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreatePhotoRequestModel model)
        {
            var userName = User.Identity.Name;
            var userId = User.GetId();

            var photo = new Photo
            {
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                UserId = userId
            };

            data.Add(photo);

            await data.SaveChangesAsync();

            return Created(nameof(Create), photo.Id);
        }
    }
}
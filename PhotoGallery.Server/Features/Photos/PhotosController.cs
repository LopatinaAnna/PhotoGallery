using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoGallery.Server.Infrastructure;
using System.Threading.Tasks;

namespace PhotoGallery.Server.Features.Photos
{
    public class PhotosController : ApiController
    {
        private readonly IPhotoService photoService;

        public PhotosController(IPhotoService photoService)
        {
            this.photoService = photoService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreatePhotoRequestModel model)
        {
            var userId = User.GetId();

            var id = await photoService.Create(model.Description, model.ImageUrl, userId);

            return Created(nameof(Create), id);
        }
    }
}
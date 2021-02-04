using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoGallery.Server.Features.Photos.Models;
using PhotoGallery.Server.Infrastructure.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoGallery.Server.Features.Photos
{
    [Authorize]
    public class PhotosController : ApiController
    {
        private readonly IPhotoService photoService;

        private readonly ICurrentUserService currentUserService;

        public PhotosController(
            IPhotoService photoService,
            ICurrentUserService currentUserService)
        {
            this.photoService = photoService;
            this.currentUserService = currentUserService;
        }

        [HttpGet]
        public async Task<IEnumerable<PhotoListModel>> Get()
        {
            return await photoService.GetPhotos(currentUserService.GetUserId());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<PhotoDetailsModel>> Details(int id)
        {
            return await photoService.GetDetails(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreatePhotoRequestModel model)
        {
            var userId = currentUserService.GetUserId();

            var id = await photoService.Create(
                model.Description,
                model.ImageUrl,
                userId);

            return Created(nameof(Create), id);
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdatePhotoRequestModel model)
        {
            var userId = currentUserService.GetUserId();

            var updated = await photoService.Update(
                model.Id,
                model.Description,
                userId);

            if (!updated)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var userId = currentUserService.GetUserId();

            var deleted = await photoService.Delete(id, userId);

            if (!deleted)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
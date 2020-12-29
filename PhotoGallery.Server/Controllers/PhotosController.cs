using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoGallery.Models.Photos;
using System.Threading.Tasks;

namespace PhotoGallery.Server.Controllers
{
    public class PhotosController : ApiController
    {
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreatePhotoModel model)
        {

        }
    }
}

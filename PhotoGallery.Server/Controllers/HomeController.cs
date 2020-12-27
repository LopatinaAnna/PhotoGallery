using Microsoft.AspNetCore.Mvc;

namespace PhotoGallery.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        //[Authorize]
        public IActionResult Get()
        {
            return Ok("ok");
        }
    }
}
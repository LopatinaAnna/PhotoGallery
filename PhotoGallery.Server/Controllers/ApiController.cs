using Microsoft.AspNetCore.Mvc;

namespace PhotoGallery.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
    }
}
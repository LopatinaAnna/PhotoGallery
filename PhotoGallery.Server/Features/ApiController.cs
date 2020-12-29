using Microsoft.AspNetCore.Mvc;

namespace PhotoGallery.Server.Features
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
    }
}
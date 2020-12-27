using System.ComponentModel.DataAnnotations;

namespace PhotoGallery.Server.Data.Models.Identity
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
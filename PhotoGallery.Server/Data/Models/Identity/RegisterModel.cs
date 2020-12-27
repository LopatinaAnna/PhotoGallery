using System.ComponentModel.DataAnnotations;

namespace PhotoGallery.Server.Data.Models.Identity
{
    public class RegisterModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
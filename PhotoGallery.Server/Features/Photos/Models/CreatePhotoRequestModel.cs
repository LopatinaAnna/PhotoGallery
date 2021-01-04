using System.ComponentModel.DataAnnotations;
using static PhotoGallery.Server.Data.Validation.Photo;

namespace PhotoGallery.Server.Features.Photos.Models
{
    public class CreatePhotoRequestModel
    {
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
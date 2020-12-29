using System.ComponentModel.DataAnnotations;
using static PhotoGallery.Server.Data.Validation.Photo;

namespace PhotoGallery.Models.Photos
{
    public class CreatePhotoModel
    {
        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}

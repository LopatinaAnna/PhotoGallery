using System.ComponentModel.DataAnnotations;
using static PhotoGallery.Server.Data.Validation.Photo;

namespace PhotoGallery.Server.Features.Photos.Models
{
    public class UpdatePhotoRequestModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }
    }
}
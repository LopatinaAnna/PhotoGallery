using PhotoGallery.Server.Data.Models.Base;
using System.ComponentModel.DataAnnotations;
using static PhotoGallery.Server.Data.Validation.Photo;

namespace PhotoGallery.Server.Data.Models
{
    public class Photo : DeletableEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
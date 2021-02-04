using System.ComponentModel.DataAnnotations;
using static PhotoGallery.Server.Data.Validation.User;

namespace PhotoGallery.Server.Data.Models
{
    public class Profile
    {
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        public string ProfilePhotoUrl { get; set; }

        public string WebSite { get; set; }

        [MaxLength(MaxBiographyLength)]
        public string Biography { get; set; }

        public Gender Gender { get; set; }

        public bool IsPrivate { get; set; }
    }
}
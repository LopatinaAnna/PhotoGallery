﻿using PhotoGallery.Server.Data.Models;

namespace PhotoGallery.Server.Features.Profiles.Models
{
    public class ProfileServiceModel
    {
        public string Name { get; set; }

        public string ProfilePhotoUrl { get; set; }

        public string WebSite { get; set; }

        public string Biography { get; set; }

        public string Gender { get; set; }

        public bool IsPrivate { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using PhotoGallery.Server.Data.Models.Base;
using System;
using System.Collections.Generic;

namespace PhotoGallery.Server.Data.Models
{
    public class User : IdentityUser, IEntity
    {
        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string ModifiedBy { get; set; }

        public IEnumerable<Photo> Photos { get; } = new HashSet<Photo>();
    }
}
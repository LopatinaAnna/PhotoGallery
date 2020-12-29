using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace PhotoGallery.Server.Data.Models
{
    public class User : IdentityUser
    {
        public IEnumerable<Photo> Photos { get; } = new HashSet<Photo>();
    }
}
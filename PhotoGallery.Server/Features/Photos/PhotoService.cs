﻿using PhotoGallery.Server.Data;
using PhotoGallery.Server.Data.Models;
using System.Threading.Tasks;

namespace PhotoGallery.Server.Features.Photos
{
    public class PhotoService : IPhotoService
    {
        private readonly ApplicationDbContext data;

        public PhotoService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public async Task<int> Create(string description, string imageUrl, string userId)
        {
            var photo = new Photo
            {
                Description = description,
                ImageUrl = imageUrl,
                UserId = userId
            };

            data.Add(photo);

            await data.SaveChangesAsync();

            return photo.Id;
        }
    }
}

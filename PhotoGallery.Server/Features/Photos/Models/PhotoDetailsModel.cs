namespace PhotoGallery.Server.Features.Photos.Models
{
    public class PhotoDetailsModel : PhotoListModel
    {
        public string Description { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }
    }
}
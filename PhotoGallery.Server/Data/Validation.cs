namespace PhotoGallery.Server.Data
{
    public class Validation
    {
        public class Photo
        {
            public const int MaxDescriptionLength = 2000;
        }

        public class User
        {
            public const int MaxNameLength = 30;

            public const int MaxBiographyLength = 30;
        }
    }
}
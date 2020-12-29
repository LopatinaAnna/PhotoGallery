using Microsoft.Extensions.Configuration;

namespace PhotoGallery.Server.Infrastructure
{
    public static class ConfigurationExtention
    {
        public static string GetDefaultConnectionString(this IConfiguration configuration)
        {
            return configuration.GetConnectionString("DefaultConnection");
        }
    }
}
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PhotoGallery.Server.Infrastructure
{
    public static class ConfigurationExtention
    {
        public static string GetDefaultConnectionString(this IConfiguration configuration)
        {
            return configuration.GetConnectionString("DefaultConnection");
        }

        public static AppSettings GetAppSettings(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            return appSettingsSection.Get<AppSettings>();
        }
    }
}
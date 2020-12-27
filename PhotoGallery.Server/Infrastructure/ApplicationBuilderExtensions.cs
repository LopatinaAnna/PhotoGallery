using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhotoGallery.Server.Data;

namespace PhotoGallery.Server.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static void ApplayMigration(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var context = services.ServiceProvider.GetService<ApplicationDbContext>();

            context.Database.Migrate();
        }
    }
}
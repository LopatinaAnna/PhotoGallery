using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhotoGallery.Server.Data;

namespace PhotoGallery.Server.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSwaggerUI(this IApplicationBuilder app)
        {
            return app.UseSwagger()
                .UseSwaggerUI(option =>
                {
                    option.SwaggerEndpoint("/swagger/v1/swagger.json", "PhotoGallery API");
                    option.RoutePrefix = string.Empty;
                });
        }

        public static void ApplayMigration(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var context = services.ServiceProvider.GetService<ApplicationDbContext>();

            context.Database.Migrate();
        }
    }
}
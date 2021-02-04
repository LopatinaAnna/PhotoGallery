using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhotoGallery.Server.Data.Models;
using PhotoGallery.Server.Data.Models.Base;
using PhotoGallery.Server.Infrastructure.Services;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PhotoGallery.Server.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        private readonly ICurrentUserService currentUserService;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            ICurrentUserService currentUserService)
            : base(options)
        {
            this.currentUserService = currentUserService;
        }

        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Photo>()
                .HasQueryFilter(c => !c.IsDeleted)
                .HasOne(x => x.User)
                .WithMany(x => x.Photos)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ApplyAuditInfo();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ApplyAuditInfo();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void ApplyAuditInfo()
            => ChangeTracker
                .Entries()
                .ToList()
                .ForEach(entry =>
                {
                    var userName = currentUserService.GetUserName();

                    if (entry.Entity is IDeletableEntity deletableEntity)
                    {
                        if (entry.State == EntityState.Deleted)
                        {
                            deletableEntity.DeletedOn = DateTime.UtcNow;
                            deletableEntity.DeletedBy = userName;
                            deletableEntity.IsDeleted = true;

                            entry.State = EntityState.Modified;

                            return;
                        }
                    }

                    if (entry.Entity is IEntity entity)
                    {
                        if (entry.State == EntityState.Added)
                        {
                            entity.CreatedOn = DateTime.UtcNow;
                            entity.CreatedBy = userName;
                        }
                        else if (entry.State == EntityState.Modified)
                        {
                            entity.ModifiedOn = DateTime.UtcNow;
                            entity.ModifiedBy = userName;
                        }
                    }
                });
    }
}
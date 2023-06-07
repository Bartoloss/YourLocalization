using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YourLocalization.Domain.Model;
using Type = YourLocalization.Domain.Model.Type;

namespace YourLocalization.Infrastructure
{
    public class Context : IdentityDbContext<User>
    {
        public DbSet<AddressDetail> AddressDetails { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<PointTag> PointTag { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Type> Types { get; set; }


        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PointTag>()
                .HasKey(it => new { it.PointId, it.TagId });

            builder.Entity<PointTag>()
                .HasOne<Point>(it => it.Point)
                .WithMany(i => i.PointTags)
                .HasForeignKey(it => it.PointId);

            builder.Entity<PointTag>()
                .HasOne<Tag>(it => it.Tag)
                .WithMany(t => t.PointTags)
                .HasForeignKey(it => it.TagId);
        }
    }
}
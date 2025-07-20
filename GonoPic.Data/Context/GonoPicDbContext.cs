using GonoPic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GonoPic.Data.Context
{
    public class GonoPicDbContext : DbContext
    {
        public GonoPicDbContext(DbContextOptions<GonoPicDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity relationships and properties here
            base.OnModelCreating(modelBuilder);

            // Composite key for MediaTag (many-to-many)
            modelBuilder.Entity<MediaTag>()
                .HasKey(mt => new { mt.MediaId, mt.TagId });

            // User → Media (uploaded by)
            modelBuilder.Entity<Media>()
                .HasOne(m => m.UploadedBy)
                .WithMany(u => u.UploadedMedia)
                .HasForeignKey(m => m.UploadedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // User → Download
            modelBuilder.Entity<Download>()
                .HasOne(d => d.User)
                .WithMany(u => u.Downloads)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        // DbSet properties for your entities
        public DbSet<User> Users { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<MediaTag> MediaTags { get; set; }
        public DbSet<Download> Downloads { get; set; }
    }
}

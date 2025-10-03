﻿using GonoPic.Domain.Entities;
using GonoPic.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GonoPic.Infrastructure.Data
{
    public class GonoPicDbContext : IdentityDbContext<ApplicationUser>
    {
        public GonoPicDbContext(DbContextOptions<GonoPicDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity relationships and properties here
            base.OnModelCreating(modelBuilder);

            // ApplicationUser → Media (uploaded by)
            modelBuilder.Entity<Media>()
                .HasOne<ApplicationUser>()
                .WithMany(u => u.UploadedMedia)
                .HasForeignKey(m => m.UploadedById)
                .OnDelete(DeleteBehavior.Restrict);

            // ApplicationUser → Download
            modelBuilder.Entity<Download>()
                .HasOne<ApplicationUser>()
                .WithMany(u => u.Downloads)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<Tag>()
                .HasIndex(t => t.Name)
                .IsUnique();
        }

        // DbSet properties for your entities
        public DbSet<Media> Media { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Download> Downloads { get; set; }
    }
}

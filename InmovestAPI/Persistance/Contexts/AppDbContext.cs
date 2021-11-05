using InmovestAPI.Domain.Models;
using InmovestAPI.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InmovestAPI.Persistance.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //POCO - Plain old CLR Object

            //Relationships
            //ejemplo:::
            /*
             builder.Entity<Category>()
                .HasMany(p => p.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId); 
            */

            //Constraints
            builder.Entity<Project>().ToTable("Projects");
            builder.Entity<Project>().HasKey(p => p.Id);
            builder.Entity<Project>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Project>().Property(p => p.Name).IsRequired().HasMaxLength(90);
            builder.Entity<Project>().Property(p => p.Description).IsRequired().HasMaxLength(1500);
            builder.Entity<Project>().Property(p => p.PhotoUrl).IsRequired().HasMaxLength(250);

            builder.UseSnakeCaseNamingConvention();
        }
    }
}
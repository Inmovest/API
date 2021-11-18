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
        public DbSet<Manager> Managers { get; set; }
        
        public DbSet<Article> Articles { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //POCO - Plain old CLR Object

            //Constraints
            builder.Entity<Manager>().ToTable("Managers");
            builder.Entity<Manager>().HasKey(p => p.Id);
            builder.Entity<Manager>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Manager>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            
            builder.Entity<Article>().ToTable("Articles");
            builder.Entity<Article>().HasKey(p => p.Id);
            builder.Entity<Article>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Article>().Property(p => p.Body).IsRequired();
            
            //Relationships
            builder.Entity<Manager>()
                .HasMany(p => p.Projects)
                .WithOne(p => p.Manager)
                .HasForeignKey(p => p.ManagerId);
            
            builder.Entity<Project>()
                .HasMany(p => p.Articles)
                .WithOne(p => p.Project)
                .HasForeignKey(p => p.ProjectId);

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
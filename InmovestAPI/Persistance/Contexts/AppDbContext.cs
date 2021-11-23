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
        
        public DbSet<Campaign> Campaigns { get; set; }

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
            
            //Constraints
            builder.Entity<Campaign>().ToTable("Managers");
            builder.Entity<Campaign>().HasKey(p => p.Id);
            builder.Entity<Campaign>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Campaign>().Property(p => p.Name).IsRequired();
            builder.Entity<Campaign>().Property(p => p.MinAmount).IsRequired();
            builder.Entity<Campaign>().Property(p => p.MaxAmount).IsRequired();
            
            //Relationships
            builder.Entity<Manager>()
                .HasMany(p => p.Projects)
                .WithOne(p => p.Manager)
                .HasForeignKey(p => p.ManagerId);

            builder.Entity<Project>()
                .HasMany(p => p.Campaigns)
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
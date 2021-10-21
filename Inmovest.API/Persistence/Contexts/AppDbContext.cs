using Inmovest.API.Domain;
using Microsoft.EntityFrameworkCore;

namespace Inmovest.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Developer> Developers { get; set; }
        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Constraints
            builder.Entity<Developer>().ToTable("Developers");
            builder.Entity<Developer>().HasKey(p => p.Id);
            builder.Entity<Developer>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Developer>().Property(p => p.CommercialName).IsRequired().HasMaxLength(30);
            
            // Relationships
            /*
            builder.Entity<Developer>()
                .HasMany(p => p.Projects)
                .WithOne(p => p.Developer)
                .HasForeignKey(p => p.DeveloperId);
            */
            
            // Seed Data
            builder.Entity<Developer>().HasData
            (
                new Developer { Id = 100, CommercialName = "Real State Pepito" },
                new Developer { Id = 101, CommercialName = "Construction Ramon"}
            );
        }
    }
}
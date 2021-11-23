using System.Collections.Generic;
using Imnovest.API.Domain;
using Inmovest.API.Domain;
using Inmovest.API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Inmovest.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Developer> Developers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Constraints Developers
            builder.Entity<Developer>().ToTable("Developers");
            builder.Entity<Developer>().HasKey(p => p.Id);
            builder.Entity<Developer>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Developer>().Property(p => p.CommercialName).IsRequired().HasMaxLength(30);
            
            // Constraints Users
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.FirstName).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.LastName).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Avatar).IsRequired();
            builder.Entity<User>().Property(p => p.Ruc).IsRequired().HasMaxLength(11);
            builder.Entity<User>().Property(p => p.Email).IsRequired();
            builder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Street).IsRequired();
            builder.Entity<User>().Property(p => p.ZipCode).IsRequired().HasMaxLength(30);
            
            // Relationships
            builder.Entity<User>()
                .HasMany(p => p.BankAccounts)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            // Seed Data for Developers
            builder.Entity<Developer>().HasData
            (
                new Developer { Id = 100, CommercialName = "Real State Pepito" },
                new Developer { Id = 101, CommercialName = "Construction Ramon"}
            );
            
            // Seed Data for Developers
            builder.Entity<User>().HasData
            (
                new User { 
                    Id = 100, 
                    FirstName = "Jose", 
                    LastName = "Vivaldi",
                    Avatar = "https://concepto.de/wp-content/uploads/2018/08/persona-e1533759204552.jpg",
                    Ruc = "123456789",
                    Email = "jvrodriguez@gmail.com",
                    Password = "*****",
                    Street = "Cedros Chorrillos, Calle 21",
                    ZipCode = "15670",
                }
            );
            
            // Seed Data for BankAccounts
            builder.Entity<BankAccount>().HasData
            (
                new BankAccount { 
                    Id = 1, 
                    Serial = "1234 5678 9123 4321", 
                    Bank = "Credit Bank of Peru",
                }
            );
            
            // Constraints BankAccounts
            builder.Entity<BankAccount>().ToTable("BankAccounts");
            builder.Entity<BankAccount>().HasKey(p => p.Id);
            builder.Entity<BankAccount>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<BankAccount>().Property(p => p.Serial).IsRequired();
            builder.Entity<BankAccount>().Property(p => p.Bank).IsRequired().HasMaxLength(30);
            
            // Relationships
            builder.Entity<BankAccount>()
                .HasOne(p => p.User)
                .WithMany(p => p.BankAccounts)
                .HasForeignKey(p => p.UserId);
            
            //Constraints  Wallets
            builder.Entity<Wallet>().ToTable("Wallets");
            builder.Entity<Wallet>().Property(p => p.Id);
            builder.Entity<Wallet>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Wallet>().Property(p => p.Balance).IsRequired();
            builder.Entity<Wallet>().Property(p => p.Frozen).IsRequired();
            
            // Relationships
            builder.Entity<Wallet>()
                .HasOne(p => p.User)
                .WithMany(p => p.Wallets)
                .HasForeignKey(p => p.UserId);
            
            // Seed Data for Wallets
            builder.Entity<Wallet>().HasData
            (
                new Wallet() { 
                    Id = 1, 
                    Balance = 12345, 
                    Frozen = true,
                }
            );
            
            //Constraints  Contracts
            builder.Entity<Contract>().ToTable("Contracts");
            builder.Entity<Contract>().Property(p => p.Id);
            builder.Entity<Contract>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Contract>().Property(p => p.Signed).IsRequired();

            // Relationships
            builder.Entity<Contract>()
                .HasOne(p => p.User)
                .WithMany(p => p.Contracts)
                .HasForeignKey(p => p.UserId);
            
            // Seed Data for Contracts
            builder.Entity<Contract>().HasData
            (
                new Contract() { 
                    Id = 1, 
                    Signed = true,
                }
            );
        }
    }
}
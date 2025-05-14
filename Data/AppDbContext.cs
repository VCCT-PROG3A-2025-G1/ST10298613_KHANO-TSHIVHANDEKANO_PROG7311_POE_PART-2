using Microsoft.EntityFrameworkCore;
using PROG7311_POE_PART_2.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PROG7311_POE_PART_2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public required DbSet<User> Users { get; set; }
        public required DbSet<Farmer> Farmers { get; set; }
        public required DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed demo data  
            modelBuilder.Entity<Farmer>().HasData(
                new Farmer { Id = 1, FullName = "Sipho Nkosi", Location = "Limpopo" },
                new Farmer { Id = 2, FullName = "Anna Molefe", Location = "KwaZulu-Natal" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "farmer1", PasswordHash = "hashedpassword1", Role = "Farmer", FarmerId = 1 },
                new User { Id = 2, Username = "employee1", PasswordHash = "hashedpassword2", Role = "Employee" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Chillies", Category = "Vegetable", ProductionDate = DateTime.Today.AddDays(-5), FarmerId = 1 },
                new Product { Id = 2, Name = "Green Beans", Category = "Vegetable", ProductionDate = DateTime.Today.AddDays(-10), FarmerId = 1 }
            );
        }
    }
}

using Microsoft.EntityFrameworkCore;
using PROG7311_POE_PART_2.Models;

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

            //seed user
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "employee",
                    Password = "password",
                    Role = "Employee"
                },
                new User
                {
                    Id = 2,
                    Username = "farmer",
                    Password = "password",
                    Role = "Farmer"
                }
            );

            modelBuilder.Entity<Farmer>().HasData(
                new Farmer
                {
                    Id = 1,
                    FullName = "Khano",
                    Location = "Limpopo"
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Chilli",
                    Category = "Vegetable",
                    ProductionDate = new DateTime(2024, 01, 15),
                    FarmerId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Butternut",
                    Category = "Vegetable",
                    ProductionDate = new DateTime(2024, 02, 20),
                    FarmerId = 1
                }
            );
        }
    }
}


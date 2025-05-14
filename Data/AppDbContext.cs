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

            // Seed a demo employee
            var employee = new User
            {
                Id = 1,
                Username = "employee",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("password"),
                Role = "Employee"
            };

            // Seed a demo farmer
            var farmerUser = new User
            {
                Id = 2,
                Username = "farmer",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("password"),
                Role = "Farmer"
            };

            var farmer = new Farmer
            {
                Id = 1,
                FullName = "Khano Sbandy",
                Location = "Limpopo",
                
            };

            var product = new Product
            {
                Id = 1,
                Name = "Chili Peppers",
                Category = "Vegetables",
                ProductionDate = DateTime.Today.AddDays(-7),
                FarmerId = 1
            };

            modelBuilder.Entity<User>().HasData(employee, farmerUser);
            modelBuilder.Entity<Farmer>().HasData(farmer);
            modelBuilder.Entity<Product>().HasData(product);
        }

    }
}

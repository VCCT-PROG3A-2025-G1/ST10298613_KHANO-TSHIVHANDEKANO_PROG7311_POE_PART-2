using Microsoft.EntityFrameworkCore;
using PROG7311_POE_PART_2.Data;
using PROG7311_POE_PART_2.Interfaces;
using PROG7311_POE_PART_2.Models;

namespace PROG7311_POE_PART_2.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        
        public ProductRepository(AppDbContext context) => _context = context;

        // Return all products, including their related farmer data
        public async Task<IEnumerable<Product>> GetAllAsync() =>
            await _context.Products.Include(p => p.Farmer).ToListAsync();

        // Return only products that belong to a specific farmer
        public async Task<IEnumerable<Product>> GetByFarmerIdAsync(int farmerId) =>
            await _context.Products.Where(p => p.FarmerId == farmerId).ToListAsync();

        // Filter products based on multiple criteria:
        // - Optional start and end date filters for production date
        // - Optional partial match for category (case-insensitive)
        public async Task<IEnumerable<Product>> FilterAsync(int farmerId, DateTime? startDate, DateTime? endDate, string? category)
        {
            // Start with products belonging to the selected farmer
            var query = _context.Products.Where(p => p.FarmerId == farmerId);

            // If a start date is given, only include products produced on/after it
            if (startDate.HasValue)
                query = query.Where(p => p.ProductionDate >= startDate.Value);

            // If an end date is given, only include products produced on/before it
            if (endDate.HasValue)
                query = query.Where(p => p.ProductionDate <= endDate.Value);

            // If a category is provided, filter by partial match (e.g., "veg" will match "vegetable")
            if (!string.IsNullOrEmpty(category))
                query = query.Where(p => p.Category.ToLower().Contains(category.ToLower()));

            // Return the filtered list of products
            return await query.ToListAsync();
        }

        // Adds a new product to the database (but does not save yet)
        public async Task AddAsync(Product product) => await _context.Products.AddAsync(product);

        // Save all changes made to the context
        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}


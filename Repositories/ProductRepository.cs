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

        public async Task<IEnumerable<Product>> GetAllAsync() =>
            await _context.Products.Include(p => p.Farmer).ToListAsync();

        public async Task<IEnumerable<Product>> GetByFarmerIdAsync(int farmerId) =>
            await _context.Products.Where(p => p.FarmerId == farmerId).ToListAsync();

        public async Task<IEnumerable<Product>> FilterAsync(int farmerId, DateTime? startDate, DateTime? endDate, string? category)
        {
            var query = _context.Products.Where(p => p.FarmerId == farmerId);

            if (startDate.HasValue)
                query = query.Where(p => p.ProductionDate >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(p => p.ProductionDate <= endDate.Value);

            if (!string.IsNullOrEmpty(category))
                query = query.Where(p => p.Category.ToLower().Contains(category.ToLower()));

            return await query.ToListAsync();
        }

        public async Task AddAsync(Product product) => await _context.Products.AddAsync(product);

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}

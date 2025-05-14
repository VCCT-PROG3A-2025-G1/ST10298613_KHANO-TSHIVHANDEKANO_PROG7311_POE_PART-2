using PROG7311_POE_PART_2.Models;

namespace PROG7311_POE_PART_2.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<IEnumerable<Product>> GetByFarmerIdAsync(int farmerId);
        Task<IEnumerable<Product>> FilterAsync(int farmerId, DateTime? startDate, DateTime? endDate, string? category);
        Task AddAsync(Product product);
        Task SaveAsync();
    }
}

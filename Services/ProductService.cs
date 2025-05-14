using PROG7311_POE_PART_2.Interfaces;
using PROG7311_POE_PART_2.Models;

namespace PROG7311_POE_PART_2.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // Add new product for a farmer
        public async Task AddProductAsync(Product product)
        {
            await _productRepository.AddAsync(product);
            await _productRepository.SaveAsync();
        }

        // Get all products from employees
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        // Get only products from a specific farmer
        public async Task<IEnumerable<Product>> GetProductsByFarmerIdAsync(int farmerId)
        {
            return await _productRepository.GetByFarmerIdAsync(farmerId);
        }

        // Filter by optional date and category
        public async Task<IEnumerable<Product>> FilterProductsAsync(int farmerId, DateTime? startDate, DateTime? endDate, string? category)
        {
            return await _productRepository.FilterAsync(farmerId, startDate, endDate, category);
        }
    }
}

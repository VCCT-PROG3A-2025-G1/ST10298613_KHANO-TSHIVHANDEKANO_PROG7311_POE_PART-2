using PROG7311_POE_PART_2.Interfaces;
using PROG7311_POE_PART_2.Models;

namespace PROG7311_POE_PART_2.Services
{
    public class FarmerService
    {
        private readonly IFarmerRepository _farmerRepository;

        public FarmerService(IFarmerRepository farmerRepository)
        {
            _farmerRepository = farmerRepository;
        }

        // Gets all farmers for employee use
        public async Task<IEnumerable<Farmer>> GetAllFarmersAsync()
        {
            return await _farmerRepository.GetAllAsync();
        }

        // Gets a single farmer by ID
        public async Task<Farmer?> GetFarmerByIdAsync(int id)
        {
            return await _farmerRepository.GetByIdAsync(id);
        }

        // Adds a new farmer (Employee function)
        public async Task AddFarmerAsync(Farmer farmer)
        {
            await _farmerRepository.AddAsync(farmer);
            await _farmerRepository.SaveAsync();
        }
    }
}

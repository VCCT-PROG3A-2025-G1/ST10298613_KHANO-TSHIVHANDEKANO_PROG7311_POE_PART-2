using PROG7311_POE_PART_2.Models;

namespace PROG7311_POE_PART_2.Interfaces
{
    public interface IFarmerRepository
    {
        Task<IEnumerable<Farmer>> GetAllAsync();
        Task<Farmer?> GetByIdAsync(int id);
        Task AddAsync(Farmer farmer);
        Task SaveAsync();
    }
}


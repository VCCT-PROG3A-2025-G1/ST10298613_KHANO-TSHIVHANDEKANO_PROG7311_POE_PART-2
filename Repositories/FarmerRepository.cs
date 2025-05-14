using Microsoft.EntityFrameworkCore;
using PROG7311_POE_PART_2.Data;
using PROG7311_POE_PART_2.Interfaces;
using PROG7311_POE_PART_2.Models;

namespace PROG7311_POE_PART_2.Repositories
{
    public class FarmerRepository : IFarmerRepository
    {
        private readonly AppDbContext _context;
        public FarmerRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Farmer>> GetAllAsync() => await _context.Farmers.ToListAsync();

        public async Task<Farmer?> GetByIdAsync(int id) => await _context.Farmers.FindAsync(id);

        public async Task AddAsync(Farmer farmer) => await _context.Farmers.AddAsync(farmer);

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}

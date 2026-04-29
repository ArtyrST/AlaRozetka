using AlaBackEnd.DAL.Entity.Products;
using AlaBackEnd.Entity;
using Microsoft.EntityFrameworkCore;

namespace AlaBackEnd.DAL.Repositories
{
    public class AdditionalServicesRepository : GenericRepository<AdditionalServicesEntity>
    {
        private readonly AppDbContext _context;
        public AdditionalServicesRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }
        public async Task<bool> IsExistByNameAsync(string name)
        {
            if (_context.AdditionalServices.Any(a => a.Name.ToLower() == name.ToLower()))
            {
                return true;
            }
            return false;
        }
        public async Task<AdditionalServicesEntity?> GetByNameAsync(string name)
        {
            return await _context
                .AdditionalServices
                .FirstOrDefaultAsync(a => a.Name.ToLower() == name.ToLower());
                
        }
        public async Task<bool> CreateRangeListAsync(List<AdditionalServicesEntity> entitis)
        {
            await _context.AdditionalServices.AddRangeAsync(entitis);
            int res = await _context.SaveChangesAsync();
            return res != 0;
        }
    }
}

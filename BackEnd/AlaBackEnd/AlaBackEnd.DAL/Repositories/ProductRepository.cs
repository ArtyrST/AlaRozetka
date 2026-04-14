


using AlaBackEnd.DAL.Entity;

using Microsoft.EntityFrameworkCore;


namespace AlaBackEnd.DAL.Repositories
{
    public class ProductRepository : GenericRepository<BaseProductEntity>
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) 
            : base(context)
        {
            _context = context;
        }
        public IQueryable<BaseProductEntity> Products => GetAll()
            .Include(p => p.Images)
            .Include(p => p.Category)
            .Include(p => p.Tags);
        

        public async Task<BaseProductEntity?> GetByNameAsync(string name)
        {
            return await Products.FirstOrDefaultAsync(p => p.Name == name);
        }
        public async Task<bool> IsExistAsync(string name)
        {
            return await GetByNameAsync(name) != null;
        }
        public async Task<bool> IsExistAsync(string name, params int[] exceptionId)
        {
            return await Products
                .AsNoTracking()
                .AnyAsync(p => p.Name.ToLower() == name.ToLower()
                && !exceptionId.Contains(p.Id));
        }
        public async Task<List<BaseProductEntity>> GetByTagAsync(List<int> tagIds)
        {
            return await _context.AllProducts
                .Include(p => p.Tags)
                .Include(p => p.Images)
                .Include(p => p.Category)
                .Where(p => p.Tags.Any(i => tagIds.Contains(i.Id)))
                .ToListAsync();
        }
        public async Task<List<BaseProductEntity>> GetAll(int PageNumber, int PageSize)
        {
            return await _context.AllProducts
                .Include(p => p.Category)
                .Include(p => p.Images)
                .Include(p => p.Tags)
                .OrderBy(p => p.Id)
                .Skip((PageNumber - 1) * PageSize) 
                .Take(PageSize)
                .ToListAsync();
        }
        
        public override async Task<BaseProductEntity?> GetByIdAsync(int id)
        {
            return await _context.AllProducts
                .Include(p => p.Images)
                .Include(p => p.Category)
                .Include(p => p.Tags)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
        
        
        




    }
}

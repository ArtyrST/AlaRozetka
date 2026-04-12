


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
        public IQueryable<BaseProductEntity> Products => GetAll();
        

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
                .Where(p => p.Tags.Any(i => tagIds.Contains(i.Id)))
                .ToListAsync();
        }
        public async Task<List<BaseProductEntity>> GetAllWithCategoryAsync(int PageNumber, int PageSize)
        {
            return await _context.AllProducts
                .Include(p => p.Category)
                .OrderBy(p => p.Id)
                .Skip((PageNumber - 1) * PageSize) 
                .Take(PageSize)
                .ToListAsync();
        }
        public async Task<List<BaseProductEntity>> GetAllWithCategoryForUpdateAsync(int id)
        {
            return await _context.AllProducts
                .Include(p => p.Category)
                .ToListAsync();
        }
        




    }
}

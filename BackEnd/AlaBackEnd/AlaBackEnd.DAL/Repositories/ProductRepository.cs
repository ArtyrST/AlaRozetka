


using AlaBackEnd.DAL.Entity;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


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
            .AsNoTracking()
            .Include(p => p.Images)
            .Include(p => p.Category)
            .Include(p => p.Tags)
            .AsSplitQuery();
        

        public async Task<BaseProductEntity?> GetByNameAsync(string name)
        {
            
            return await Products.FirstOrDefaultAsync(p => p.Name == name);
        }
        public async Task<bool> IsExistAsync(string name)
        {
            return await Products.AnyAsync(p => p.Name.ToLower() == name.ToLower());
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
                .AsSplitQuery()
                .ToListAsync();
        }
        public async Task<List<BaseProductEntity>> GetAll(int PageNumber, int PageSize)
        {
            var currentPage = PageNumber < 1 ? 1 : PageNumber;

            // 2. Тепер розрахунок skip ніколи не дасть негативне число.
            // (1 - 1) * 20 = 0 (мінімум)
            int skip = (currentPage - 1) * PageSize;

            return await _context.AllProducts
                .AsNoTracking()
                .Include(p => p.Category)
                .Include(p => p.Images)
                .Include(p => p.Tags)
                .OrderBy(p => p.Id)
                .Skip(skip) 
                .Take(PageSize)
                .AsSplitQuery()
                .ToListAsync();
        }
        
        public override async Task<BaseProductEntity?> GetByIdAsync(int id)
        {
            return await _context.AllProducts
                //.AsNoTracking()
                .Include(p => p.Images)
                .Include(p => p.Category)
                .Include(p => p.Tags)
                //.AsSplitQuery()
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<List<BaseProductEntity>> GetRangeByIdAsync(List<int> id)
        {
            return await _context.AllProducts
                .Where(p => id.Contains(p.Id))
                .AsNoTracking()
                .ToListAsync();
        }
    }
        
        
        




}


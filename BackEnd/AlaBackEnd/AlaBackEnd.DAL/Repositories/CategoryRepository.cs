using AlaBackEnd.Entity.Products;
using Microsoft.EntityFrameworkCore;


namespace AlaBackEnd.DAL.Repositories
{
    public class CategoryRepository : GenericRepository<CategoryEntity>
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }
        public IQueryable<CategoryEntity> Categories => GetAll();
        public async Task<CategoryEntity> GetAllAsync(int id)
        {
            return await Categories.FirstOrDefaultAsync(c => c.Id == id);
        }
        
    }
}

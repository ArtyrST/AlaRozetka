


using AlaBackEnd.DAL.Entity;

namespace AlaBackEnd.DAL.Repositories
{
    public class ProductRepository : GenericRepository<BaseProductEntity>
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) 
            : base(context)
        {
            
        }
        public IQueryable<BaseProductEntity> Products => GetAll();

    }
}

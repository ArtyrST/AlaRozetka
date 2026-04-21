using Microsoft.EntityFrameworkCore;
using AlaBackEnd.DAL.Entity.ProductCart;

namespace AlaBackEnd.DAL.Repositories
{
    public class UserCartRepository : GenericRepository<CartEntity>      
    {
        private readonly AppDbContext _context;
        public UserCartRepository(AppDbContext context)
            :base (context)
        {
            _context = context;
        }

    }
}

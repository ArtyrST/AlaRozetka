using AlaBackEnd.DAL.Entity.ProductCart;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.DAL.Repositories
{
    public class ProductCartRepository : GenericRepository<CartEntity>
    {
        private readonly AppDbContext _context;
        public ProductCartRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }
        public IQueryable<CartEntity> carts => GetAll()
            .Include(c => c.OrderItems)
            .Include(c => c.User)
            .AsSingleQuery();
            //.AsNoTracking();
        public async Task<CartEntity?> GetByUserIdAsync(int id)
        {
            return await carts
                .FirstOrDefaultAsync(c => c.UserId == id);
                
        }
    }
}

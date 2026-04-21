using AlaBackEnd.DAL.Entity.ProductCart;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.DAL.Repositories
{
    public class OrderRepository : GenericRepository<OrderItemEntity>    
    {
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }
        private IQueryable<OrderItemEntity> items => GetAll()
            .Include(i => i.Product)
            .AsNoTracking();
        public async Task<bool> IsExistAsync(int id)
        {
            return await _context.OrderItems.AnyAsync(p => p.Id == id);
        }
        public async Task<bool> IsDateOverlap(int ProdId, DateTime From, DateTime To)
        {
            var prod = await items.FirstOrDefaultAsync(p => p.ProductId == ProdId);
            if (prod == null)
            {
                return true;
            }
            

            return !(prod.TimeFrom < To && prod.TimeTo > From);

        }
        public async Task<double> PriceCounterAsync(double period, int prodId)
        {
            var prod = await _context.AllProducts.FirstOrDefaultAsync(p => p.Id == prodId);
            if (prod == null)
            {
                throw new KeyNotFoundException("Product was not found");
            }    
            return (period * prod.Price);
        }
        

    }
}

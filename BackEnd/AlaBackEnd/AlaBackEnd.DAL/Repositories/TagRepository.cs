using AlaBackEnd.DAL.Entity.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.DAL.Repositories
{
    public class TagRepository : GenericRepository<ProductTagEntity> 
    {
        private readonly AppDbContext _context;
        public TagRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }
        public IQueryable<ProductTagEntity> tags => GetAll();
        public async Task<ProductTagEntity?> GetByNameAsync(string name)
        {
            return await tags.FirstOrDefaultAsync(t => t.Name == name);
        }
        public async Task<List<ProductTagEntity>?> GetByIdAsync(List<int> id)
        {
            return await tags
                .Where(t => id.Contains(t.Id))
                .ToListAsync();
                
        }
    }
}

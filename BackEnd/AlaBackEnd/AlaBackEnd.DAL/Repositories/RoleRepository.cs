using AlaBackEnd.DAL.Entity.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.DAL.Repositories
{
    public class RoleRepository : GenericRepository<RoleEntity>
    {
        private readonly AppDbContext _context;
        public RoleRepository(AppDbContext context)
            : base(context) 
        {
            _context = context;
        }
        public async Task<RoleEntity?> GetByNameAsync(string name)
        {
            return await _context.Roles
                .FirstOrDefaultAsync(r => r.Name == name);
                
        }

    }
}

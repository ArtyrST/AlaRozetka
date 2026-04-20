using AlaBackEnd.DAL.Entity.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.DAL.Repositories
{
    public class UserRepository : GenericRepository<UserEntity>
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }
        public IQueryable<UserEntity> users => GetAll()
            .Include(u => u.Roles);

        public async Task<UserEntity?> GetByMailAsync(string mail)
        {
            return await _context.Users
                .Include(u => u.Roles)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == mail);
                
                
        }
        public async Task<bool> IsExistAsync(string mail)
        {
            return await GetByMailAsync(mail) != null;
        }
        public async Task<bool> IsExistAsync(string name, params int[] exceptionId)
        {
            return await users
                .AsNoTracking()
                .AnyAsync(p => p.FirstName.ToLower() == name.ToLower()
                && !exceptionId.Contains(p.Id));
        }

        
        
    }
}

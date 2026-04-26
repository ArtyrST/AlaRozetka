using AlaBackEnd.DAL.Entity.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.DAL.Repositories
{
    public class PandingUserPerository : GenericRepository<PandingUserEntity>
    {
        private readonly AppDbContext _context;
        public PandingUserPerository(AppDbContext context)
            : base (context)
        {
            _context = context;
        }
        public async Task<PandingUserEntity?> GetByEmailAsync(string email)
        {
            return await _context.PandingUsers
                .FirstOrDefaultAsync(p => p.Email == email);
        }
    }
}

using AlaBackEnd.DAL.Entity.Users;
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

    }
}

using AlaBackEnd.DAL.Entity.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.DAL.Repositories
{
    public class RieltorRequestsRepository : GenericRepository<RieltorAcceptEntity>
    {
        private readonly AppDbContext _context;
        public RieltorRequestsRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }
        public IQueryable<RieltorAcceptEntity> requests => GetAll();
    }
}

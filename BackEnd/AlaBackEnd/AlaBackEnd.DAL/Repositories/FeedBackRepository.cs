using AlaBackEnd.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.DAL.Repositories
{
    public class FeedBackRepository : GenericRepository<FeedBackEntity>
    {
        public readonly AppDbContext _context;
        public FeedBackRepository(AppDbContext context)
            :base (context)
        {
            _context = context;
        }
    }
}

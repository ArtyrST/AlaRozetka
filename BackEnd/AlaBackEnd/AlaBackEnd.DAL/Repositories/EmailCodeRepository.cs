using AlaBackEnd.DAL.Entity.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.DAL.Repositories
{
    public class EmailCodeRepository : GenericRepository<EmailCodeEntity>
    {
        private readonly AppDbContext _context;
        public EmailCodeRepository(AppDbContext context)
            : base (context)
        {
            _context = context;
        }
        public IQueryable<EmailCodeEntity> codes => GetAll();
        //public async Task<bool> CreateCodeAsync()
    }
}

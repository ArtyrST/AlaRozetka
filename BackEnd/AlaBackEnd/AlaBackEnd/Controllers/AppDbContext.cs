using AlaBackEnd.Entity;
using Microsoft.EntityFrameworkCore;

namespace AlaBackEnd.Controllers
{
    public class AppDbContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            string DbConnectionString = "Server=localhost\\MSSQLSERVER03;Database=master;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(DbConnectionString);

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<ProductEntity>()
                .HasKey(p => p.Id);

        }
    }
}

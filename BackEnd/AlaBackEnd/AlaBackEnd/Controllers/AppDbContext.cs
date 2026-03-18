using AlaBackEnd.Entity;
using Microsoft.EntityFrameworkCore;

namespace AlaBackEnd.Controllers
{
    public class AppDbContext : DbContext
    {
        public DbSet<ProductLaptopEntity> Products { get; set; }
        public DbSet<CategoryEntity> categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            string DbConnectionString = "Server=localhost\\MSSQLSERVER03;Database=master;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(DbConnectionString);

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            //Product
            builder.Entity<ProductLaptopEntity>()
                .HasKey(p => p.Id);





            //Category
            builder.Entity<CategoryEntity>()
                .HasKey(p => p.Id);
        }
    }
}

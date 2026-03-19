using AlaBackEnd.DAL.Entity.Users;
using AlaBackEnd.Entity.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;



namespace AlaBackEnd.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<ProductLaptopEntity> Laptops { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductMonitorEntity> Monitores { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        
        
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            //User
            builder.Entity<UserEntity>()
                .HasKey(u => u.Id);

            builder.Entity<UserEntity>()
                .Property(u => u.Email)
                .IsRequired(true)
                .HasMaxLength(80);

            builder.Entity<UserEntity>()
                .Property(u => u.FirstName)
                .HasMaxLength(20)
                .IsRequired(true);

            builder.Entity<UserEntity>()
                .Property(u => u.LastName)
                .HasMaxLength(30);

            //Roles
            builder.Entity<RoleEntity>()
                .HasKey(r => r.Id);

            builder.Entity<RoleEntity>()
                .Property(r => r.Name)
                .HasMaxLength(20);




            //Category
            builder.Entity<CategoryEntity>()
                .HasKey(p => p.Id);

            builder.Entity<CategoryEntity>()
                .Property(p => p.Name)
                .HasMaxLength(52)
                .IsRequired(true);
            
            
            
                
                
            
                //ProductLapTop
            builder.Entity<ProductLaptopEntity>()
                .HasKey(p => p.Id);

            builder.Entity <ProductLaptopEntity>()
                .Property(p => p.Name)
                .HasMaxLength(200)
                .IsRequired(true);

            builder.Entity<ProductLaptopEntity>()
                .Property(p => p.Description)
                .HasColumnType("text");

                // ProductMonitor
            builder.Entity<ProductMonitorEntity>()
                .HasKey(p =>p.Id);

            builder.Entity<ProductMonitorEntity>()
                .Property(p => p.Name)
                .HasColumnType("text")
                .IsRequired(true);

            builder.Entity<ProductMonitorEntity>()
                .Property(p => p.Description)
                .HasColumnType("text");

            //relation laptops with category
            builder.Entity<ProductLaptopEntity>()
                .HasOne(p => p.Category)
                .WithMany(p => p.Laptops)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            //relation monitors with category
            builder.Entity<ProductMonitorEntity>()
                .HasOne(p => p.Category)
                .WithMany(p => p.Monitors)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);
            //relation user with role
            builder.Entity<UserEntity>(entity =>
            {
                entity.HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity("UserRoles");
            });

        }        
    }
}

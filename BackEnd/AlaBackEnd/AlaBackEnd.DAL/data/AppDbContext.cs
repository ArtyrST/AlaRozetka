using AlaBackEnd.DAL.Entity.ProductCart;
using AlaBackEnd.DAL.Entity.Products;
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
        public DbSet<BaseProductEntity> AllProducts { get; set; }
        public DbSet<CartEntity> Carts { get; set; }
        public DbSet<OrderItemEntity> OrderItems { get; set; }
        
        
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




            //BaseProduct
            builder.Entity<BaseProductEntity>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name).IsRequired(true).HasMaxLength(100);
                
            });

            //ProductLapTop


            
            builder.Entity<ProductLaptopEntity>(entity =>
            {
                entity.Property(l => l.Brand).HasMaxLength(30);
                
            });

            // ProductMonitor
            builder.Entity<ProductMonitorEntity>(entity =>
            {
                entity.Property(m => m.Brand).HasMaxLength(30);

            });


            //relation laptops with category
            builder.Entity<BaseProductEntity>()
                .HasOne(p => p.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            
            //relation user with role
            builder.Entity<UserEntity>(entity =>
            {
                entity.HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity("UserRoles");
            });

            //relation Cart with OrderItem
            builder.Entity<CartEntity>(entity =>
            {
                entity.HasMany(c => c.OrderItems)
                    .WithOne(c => c.Cart)
                    .HasForeignKey(c => c.CartId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            //relation Cart with User
            builder.Entity<UserEntity>(entity =>
            {
                entity.HasOne(c => c.Cart)
                .WithOne(c => c.User)
                .HasForeignKey<CartEntity>(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            //relation OrderItem with BaseProduct
            builder.Entity<OrderItemEntity>(entity =>
            {
                entity.HasOne(o => o.Product)
                    .WithMany()
                    .HasForeignKey(o => o.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);



            });
        }        
    }
}

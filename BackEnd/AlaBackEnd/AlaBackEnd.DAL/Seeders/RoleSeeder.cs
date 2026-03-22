using AlaBackEnd.DAL.Entity.Products;
using AlaBackEnd.DAL.Entity.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AlaBackEnd.DAL.Seeders
{
    public static class RoleSeeder
    {
        public static async Task SeedAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            using var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            await dbContext.Database.MigrateAsync();

            var roles = new List<RoleEntity>();
            if (!dbContext.Roles.Any())
            {
                roles = new List<RoleEntity>
                    {
                    new RoleEntity {Name = "Admin"},
                    new RoleEntity {Name = "Guest"},
                    new RoleEntity {Name = "Rieltor"}

                    };
                
                await dbContext.Roles.AddRangeAsync(roles);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                roles = await dbContext.Roles.AsNoTracking().ToListAsync();
            }

        //    public int Id { get; set; }
        //public required string Name { get; set; } = string.Empty;
        //public double Price { get; set; }
        //public string Country { get; set; } = string.Empty;

            var hotels = new List<BaseProductEntity>();

            if (!dbContext.AllProducts.Any())
            {
                hotels = new List<BaseProductEntity>()
                {
                    new BaseProductEntity{Name = "SpermaSraka", Price = 2999, Country = "Ukraine"}

                };
                await dbContext.AllProducts.AddRangeAsync(hotels);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                hotels = await dbContext.AllProducts.AsNoTracking().ToListAsync();

            }
    }
    }
}

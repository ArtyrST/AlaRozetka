using AlaBackEnd.DAL.Entity.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace AlaBackEnd.DAL.Seeders
{
    public static class RoleSeeder
    {
        public static void Seed(AppDbContext context)
        {
            context.Database.Migrate();

            RolesSeeder(context);

        }
        private static void RolesSeeder(AppDbContext context)
        {
            if (!context.Roles.Any())
            {
                var admin_roles = new RoleEntity { Name = "admin" };
                var user_admin = new UserEntity { FirstName = "admin", LastName = "admin", Email = "stadnikartyr@gmail.com" };

                user_admin.Roles.Add(admin_roles);

                context.Users.Add(user_admin);
                context.SaveChanges();
            }
        }
    }
}

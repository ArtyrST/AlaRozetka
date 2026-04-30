using AlaBackEnd.DAL.Entity;
using AlaBackEnd.DAL.Entity.Products;
using AlaBackEnd.DAL.Entity.Users;
using AlaBackEnd.Entity.Products;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace AlaBackEnd.DAL.Seeders
{
    public static class RoleSeeder
    {
        public static async Task SeedAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            using var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            await dbContext.Database.MigrateAsync();

            var addServices = new List<AdditionalServicesEntity>();
            if (!dbContext.AdditionalServices.Any())
            {
                addServices = new List<AdditionalServicesEntity>
                {
                    new AdditionalServicesEntity { Name = "Сніданок у номер", Price = 350 },
                    new AdditionalServicesEntity { Name = "Трансфер до аеропорту", Price = 800 },
                    new AdditionalServicesEntity { Name = "Оренда конференц-залу (1 година)", Price = 1200 },
                    new AdditionalServicesEntity { Name = "Послуги пральні та прасування", Price = 250 },
                    new AdditionalServicesEntity { Name = "Міні-бар (стандартне наповнення)", Price = 500 },
                    new AdditionalServicesEntity { Name = "Відвідування SPA-зони", Price = 600 },
                    new AdditionalServicesEntity { Name = "Масаж класичний (60 хв)", Price = 1100 },
                    new AdditionalServicesEntity { Name = "Оренда велосипеда (день)", Price = 400 },
                    new AdditionalServicesEntity { Name = "Додаткове спальне місце", Price = 700 },
                    new AdditionalServicesEntity { Name = "Проживання з тваринами", Price = 500 },
                    new AdditionalServicesEntity { Name = "Ранній заїзд", Price = 900 },
                    new AdditionalServicesEntity { Name = "Пізній виїзд", Price = 900 },
                    new AdditionalServicesEntity { Name = "Екскурсія містом з гідом", Price = 1500 },
                    new AdditionalServicesEntity { Name = "Парковка під охороною (доба)", Price = 200 },
                    new AdditionalServicesEntity { Name = "Пляшка ігристого вина у номер", Price = 750 },
                    new AdditionalServicesEntity { Name = "Фруктова корзина", Price = 450 },
                    new AdditionalServicesEntity { Name = "Послуги няні (1 година)", Price = 300 },
                    new AdditionalServicesEntity { Name = "Оренда автомобіля", Price = 2500 },
                    new AdditionalServicesEntity { Name = "Квитки на театральну виставу", Price = 1000 },
                    new AdditionalServicesEntity { Name = "Хімчистка взуття", Price = 150 }
                };
                await dbContext.AdditionalServices.AddRangeAsync(addServices);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                addServices = await dbContext.AdditionalServices.AsNoTracking().ToListAsync();

            }

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

            //tag seeder
            var tags = new List<ProductTagEntity>();
            if (!dbContext.ProductTag.Any())
            {
                tags = new List<ProductTagEntity>
                {
                    // --- Зручності в номері (Room Amenities) ---
                    new ProductTagEntity {Name = "Wi-Fi"},
                    new ProductTagEntity {Name = "Air Conditioning"},
                    new ProductTagEntity {Name = "TV"},
                    new ProductTagEntity {Name = "Minibar"},
                    new ProductTagEntity {Name = "SafeBox"},
                    new ProductTagEntity {Name = "Kitchenette"},
                    new ProductTagEntity {Name = "Balcony"},
                    new ProductTagEntity {Name = "Sea View"},
                    new ProductTagEntity {Name = "Mountain View"},
                    new ProductTagEntity {Name = "City View"},
                    new ProductTagEntity {Name = "Soundproofing"},
                    new ProductTagEntity {Name = "Jacuzzi in Room"},
                    new ProductTagEntity {Name = "Coffee Machine"},
                    new ProductTagEntity {Name = "Work Desk"},
                    new ProductTagEntity {Name = "Ironing Facilities"},
                    new ProductTagEntity {Name = "Bathrobe & Slippers"},
                    new ProductTagEntity {Name = "Fireplace"},
                    new ProductTagEntity {Name = "Private Entrance"},
                    new ProductTagEntity {Name = "Terrace"},
                    new ProductTagEntity {Name = "Heating"},

                    // --- Харчування (Dining) ---
                    new ProductTagEntity {Name = "Breakfast Included"},
                    new ProductTagEntity {Name = "All Inclusive"},
                    new ProductTagEntity {Name = "Restaurant"},
                    new ProductTagEntity {Name = "Bar"},
                    new ProductTagEntity {Name = "Cafe"},
                    new ProductTagEntity {Name = "Room Service"},
                    new ProductTagEntity {Name = "Vegetarian Options"},
                    new ProductTagEntity {Name = "Halal Food"},
                    new ProductTagEntity {Name = "Buffet"},
                    new ProductTagEntity {Name = "Wine/Champagne"},
                    new ProductTagEntity {Name = "Kid-Friendly Buffet"},
                    new ProductTagEntity {Name = "Snack Bar"},

                    // --- Розваги та Спорт (Leisure & Sport) ---
                    new ProductTagEntity {Name = "Swimming Pool"},
                    new ProductTagEntity {Name = "Infinity Pool"},
                    new ProductTagEntity {Name = "Indoor Pool"},
                    new ProductTagEntity {Name = "Outdoor Pool"},
                    new ProductTagEntity {Name = "Gym"},
                    new ProductTagEntity {Name = "Spa & Wellness"},
                    new ProductTagEntity {Name = "Sauna"},
                    new ProductTagEntity {Name = "Hammam"},
                    new ProductTagEntity {Name = "Massage"},
                    new ProductTagEntity {Name = "Billiards"},
                    new ProductTagEntity {Name = "Tennis Court"},
                    new ProductTagEntity {Name = "Golf Course"},
                    new ProductTagEntity {Name = "Bowling"},
                    new ProductTagEntity {Name = "Diving"},
                    new ProductTagEntity {Name = "Ski-to-Door Access"},
                    new ProductTagEntity {Name = "Bicycle Rental"},
                    new ProductTagEntity {Name = "Nightclub"},
                    new ProductTagEntity {Name = "Casino"},

                    // --- Послуги готелю (General Services) ---
                    new ProductTagEntity {Name = "Parking"},
                    new ProductTagEntity {Name = "Free Parking"},
                    new ProductTagEntity {Name = "EV Charging Station"},
                    new ProductTagEntity {Name = "Airport Shuttle"},
                    new ProductTagEntity {Name = "24-Hour Front Desk"},
                    new ProductTagEntity {Name = "Concierge Service"},
                    new ProductTagEntity {Name = "Laundry"},
                    new ProductTagEntity {Name = "Dry Cleaning"},
                    new ProductTagEntity {Name = "Daily Housekeeping"},
                    new ProductTagEntity {Name = "Business Center"},
                    new ProductTagEntity {Name = "Meeting/Banquet Facilities"},
                    new ProductTagEntity {Name = "ATM on Site"},
                    new ProductTagEntity {Name = "Currency Exchange"},
                    new ProductTagEntity {Name = "Luggage Storage"},
                    new ProductTagEntity {Name = "Tour Desk"},

                    // --- Сім'я та Тварини (Family & Pets) ---
                    new ProductTagEntity {Name = "Pet Friendly"},
                    new ProductTagEntity {Name = "Family Rooms"},
                    new ProductTagEntity {Name = "Kids Club"},
                    new ProductTagEntity {Name = "Playground"},
                    new ProductTagEntity {Name = "Babysitting Services"},
                    new ProductTagEntity {Name = "Strollers"},

                    // --- Доступність та Тип (Accessibility & Type) ---
                    new ProductTagEntity {Name = "Elevator"},
                    new ProductTagEntity {Name = "Wheelchair Accessible"},
                    new ProductTagEntity {Name = "Adults Only"},
                    new ProductTagEntity {Name = "Non-Smoking Rooms"},
                    new ProductTagEntity {Name = "Designated Smoking Area"},
                    new ProductTagEntity {Name = "Boutique Hotel"},
                    new ProductTagEntity {Name = "Hostel"},
                    new ProductTagEntity {Name = "Apart-hotel"},
                    new ProductTagEntity {Name = "Resort"},
                    new ProductTagEntity {Name = "Villa"},

                    // --- Локація та Атмосфера (Location & Vibe) ---
                    new ProductTagEntity {Name = "Beachfront"},
                    new ProductTagEntity {Name = "Private Beach"},
                    new ProductTagEntity {Name = "Lake View"},
                    new ProductTagEntity {Name = "River View"},
                    new ProductTagEntity {Name = "Near Metro"},
                    new ProductTagEntity {Name = "City Center"},
                    new ProductTagEntity {Name = "Quiet Area"},
                    new ProductTagEntity {Name = "Historical Building"},
                    new ProductTagEntity {Name = "Eco-Friendly"},
                    new ProductTagEntity {Name = "Luxury"},
                    new ProductTagEntity {Name = "Budget Friendly"},
                    new ProductTagEntity {Name = "Romantic"},
                    new ProductTagEntity {Name = "Business Travel"},

                    // --- Безпека та Здоров'я (Safety & Health) ---
                    new ProductTagEntity {Name = "CCTV in Common Areas"},
                    new ProductTagEntity {Name = "Fire Extinguishers"},
                    new ProductTagEntity {Name = "Smoke Alarms"},
                    new ProductTagEntity {Name = "Security 24/7"},
                    new ProductTagEntity {Name = "First Aid Kit"},
                    new ProductTagEntity {Name = "Doctor on Call"}
                };
                await dbContext.ProductTag.AddRangeAsync(tags);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                tags = await dbContext.ProductTag.AsNoTracking().ToListAsync();
            }


                var categories = new List<CategoryEntity>();
            if (!dbContext.Categories.Any())
            {
                categories = new List<CategoryEntity>
                {
                    new CategoryEntity { Name = "Готелі"},
                    new CategoryEntity { Name = "Апартаменти"},
                    new CategoryEntity { Name = "Хостели"},
                    new CategoryEntity { Name = "Вілли"},
                    new CategoryEntity { Name = "Глемпінги"}
                };
                await dbContext.Categories.AddRangeAsync(categories);
                await dbContext.SaveChangesAsync();

            }
            else
            {
                categories = await dbContext.Categories.AsNoTracking().ToListAsync();
            }

            //    public int Id { get; set; }
            //public required string Name { get; set; } = string.Empty;
            //public double Price { get; set; }
            //public string Country { get; set; } = string.Empty;

            

            //if (!dbContext.AllProducts.Any())
            //{
            //    hotels = new List<BaseProductEntity>()
            //    {
            //        new BaseProductEntity{Name = "SpermaSraka", Price = 2999, Country = "Ukraine", CategoryName = "Hotels", CategoryId = 0, City = "Lutsk"}

            //    };
            //    await dbContext.AllProducts.AddRangeAsync(hotels);
            //    await dbContext.SaveChangesAsync();
            //}
            //else
            //{
            //    hotels = await dbContext.AllProducts.AsNoTracking().ToListAsync();

            //    //}

            //    //caterogies
            //    var categories = new List<CategoryEntity>();

            //    if (!dbContext.Categories.Any())
            //    {
            //        categories = new List<CategoryEntity>()
            //    {
            //        new CategoryEntity{Name = "Hotels"},
            //        new CategoryEntity{Name = "Villas"}
            //    };
            //        await dbContext.Categories.AddRangeAsync(categories);
            //        await dbContext.SaveChangesAsync();
            //    }
            //    else
            //    {
            //        categories = await dbContext.Categories.AsNoTracking().ToListAsync();
            //    }
            //}
        }
    }
}

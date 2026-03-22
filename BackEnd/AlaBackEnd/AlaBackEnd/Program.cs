using AlaBackEnd.BLL;
using AlaBackEnd.DAL;
using AlaBackEnd.DAL.Seeders;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using System.Threading.Tasks;



namespace AlaBackEnd
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            //EF core connect
            
            

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsAssembly("AlaBackEnd.DAL")
                    );
                

                
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();

                app.MapScalarApiReference(options =>
                {
                    options.WithTitle("AlaRozetka API")
                           .WithTheme(ScalarTheme.Moon) // Можна вибрати тему: Solarized, BluePlanet тощо
                           .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            
            app.MapControllers();

            //await app.SeedAsync();

            app.Run();
        }
    }
}

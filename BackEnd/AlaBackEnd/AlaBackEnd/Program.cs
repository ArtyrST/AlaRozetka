
using AlaBackEnd.BLL.Services;
using AlaBackEnd.BLL.Services.ImagesService;
using AlaBackEnd.DAL;
using AlaBackEnd.DAL.Repositories;
using AlaBackEnd.DAL.Seeders;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Scalar.AspNetCore;





namespace AlaBackEnd
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            //add repos
            builder.Services.AddScoped<ProductRepository>();
            builder.Services.AddScoped<TagRepository>();
            builder.Services.AddScoped<CategoryRepository>();
            
            
            
            //add services
            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<TagServise>();
            builder.Services.AddScoped<ImageService>();
            //add automapper
            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
            });
            //builder.Services.AddAutoMapper(cfg =>
            //{
            //    cfg.LicenseKey = ""
            //});


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

            builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
                    policy
                    .AllowAnyOrigin()

                    .AllowAnyHeader()
                    .AllowAnyMethod()));

            // ... нижче перед MapControllers
            

            var app = builder.Build();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(builder.Environment.ContentRootPath, "Uploads")),
                    RequestPath = "/uploads"
            });
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
            if (!app.Environment.IsDevelopment())
            {
                app.UseHttpsRedirection();
            }
                app.UseCors();
            app.UseAuthorization();


            
            app.MapControllers();

            await app.SeedAsync();

            app.Run();
        }
    }
}

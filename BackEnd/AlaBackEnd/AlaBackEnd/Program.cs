
using AlaBackEnd.BLL.Services;
using AlaBackEnd.BLL.Services;
using AlaBackEnd.BLL.Services.Interfaces;
using AlaBackEnd.BLL.Services.LoginService;
using AlaBackEnd.BLL.Services.ProductsService;
using AlaBackEnd.DAL;
using AlaBackEnd.DAL.Repositories;
using AlaBackEnd.DAL.Seeders;
using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;
using System.Text.Json.Serialization;





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
            builder.Services.AddScoped<UserRepository>();
            builder.Services.AddScoped<RoleRepository>();
            builder.Services.AddScoped<OrderRepository>();
            builder.Services.AddScoped<UserCartRepository>();
            builder.Services.AddScoped<FeedBackRepository>();
            builder.Services.AddScoped<EmailCodeRepository>();
            builder.Services.AddScoped<PandingUserPerository>();
            builder.Services.AddScoped<ProductCartRepository>();
            builder.Services.AddScoped<RieltorRequestsRepository>();
            builder.Services.AddScoped<AdditionalServicesRepository>();


            //add services
            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<TagServise>();
            builder.Services.AddScoped<ImageService>();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<JwtService>();
            builder.Services.AddScoped<OrderItemService>();
            builder.Services.AddScoped<FeedBackService>();
            builder.Services.AddScoped<EmailVerifService>();
            builder.Services.AddScoped<IProductCartInterface, ProductCartService>();
            builder.Services.AddScoped<IRieltorAcceptService, RieltorRequestsService>();
            builder.Services.AddScoped<AdditionalServicesService>();
            
            //add automapper
            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
            });
            //builder.Services.AddAutoMapper(cfg =>
            //{
            //    cfg.LicenseKey = ""
            //});



            builder.Services.AddHttpContextAccessor();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });

            builder.Services.AddAuthorization();
           

            //EF core connect
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsAssembly("AlaBackEnd.DAL")
                    );
                

                
            });

            // Add services to the container.

            builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();


            //TODO: Change .AllowAnyOrigins()
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
            app.UseStaticFiles();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                
                app.MapOpenApi();

                app.MapScalarApiReference(options =>
                {
                    options.WithTitle("AlaRozetka API")
               .WithTheme(ScalarTheme.Moon)
               .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient)
               // Додаємо інтерфейс документації за стандартним шляхом
               .WithEndpointPrefix("/scalar/{documentName}");

                });
                

            }

            if (!app.Environment.IsDevelopment())
            {
                app.UseHttpsRedirection();
            }
                app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseStaticFiles();
            app.MapControllers();

            //await app.SeedAsync();

            app.Run();
        }
    }
}

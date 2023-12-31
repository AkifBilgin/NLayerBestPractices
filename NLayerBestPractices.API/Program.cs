using Microsoft.EntityFrameworkCore;
using NLayerBestPractices.Core.Repositories;
using NLayerBestPractices.Core.Services;
using NLayerBestPractices.Core.UnitOfWorks;
using NLayerBestPractices.Service.Mapping;
using NLayerBestPractices.Service.Services;
using NLayerBestPratices.Repository;
using NLayerBestPratices.Repository.Repositories;
using NLayerBestPratices.Repository.UnitOfWork;
using System.Reflection;

namespace NLayerBestPractices.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped(typeof(IService<>), typeof(Services<>));
            builder.Services.AddAutoMapper(typeof(MapProfile));
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductServiceWithNoCahcing>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();

            builder.Services.AddDbContextPool<AppDbContext>(x =>
            {
                x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), options =>
                {
                    options.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
                });

            });
           
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

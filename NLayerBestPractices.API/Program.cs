using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLayerBestPractices.API.Filters;
using NLayerBestPractices.API.Middlewares;
using NLayerBestPractices.API.Modules;
using NLayerBestPractices.Core.Repositories;
using NLayerBestPractices.Core.Services;
using NLayerBestPractices.Core.UnitOfWorks;
using NLayerBestPractices.Service.Mapping;
using NLayerBestPractices.Service.Services;
using NLayerBestPractices.Service.Validations;
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

            builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute())).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>());
            //Only by APi in MVC not active
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddMemoryCache();

            builder.Services.AddScoped(typeof(NotFoundFilter<>));
            builder.Services.AddAutoMapper(typeof(MapProfile));


            builder.Services.AddDbContextPool<AppDbContext>(x =>
            {
                x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), options =>
                {
                    options.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
                });

            });
        
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(container => container.RegisterModule(new RepoServiceModule()));
            
        
            
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCustomException();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

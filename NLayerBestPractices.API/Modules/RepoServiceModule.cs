using Autofac;
using NLayer.Caching;
using NLayerBestPractices.Core.Entities;
using NLayerBestPractices.Core.Repositories;
using NLayerBestPractices.Core.Services;
using NLayerBestPractices.Core.UnitOfWorks;
using NLayerBestPractices.Service.Services;
using NLayerBestPratices.Repository;
using NLayerBestPratices.Repository.Repositories;
using NLayerBestPratices.Repository.UnitOfWork;
using System.Reflection;
using Module = Autofac.Module;

namespace NLayerBestPractices.API.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Services<>)).As(typeof(IService<>)).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            var apiAssembly = Assembly.GetExecutingAssembly();

            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            
            var serviceAssembly = Assembly.GetAssembly(typeof(ProductServiceWithNoCaching));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x=>x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<ProductServiceWithCaching>().As<IProductService>();
        }
    }
}

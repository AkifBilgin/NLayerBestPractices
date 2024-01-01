using Autofac;
using NLayerBestPractices.Core.Repositories;
using NLayerBestPractices.Core.Services;
using NLayerBestPractices.Core.UnitOfWorks;
using NLayerBestPractices.Service.Mapping;
using NLayerBestPractices.Service.Services;
using NLayerBestPratices.Repository;
using NLayerBestPratices.Repository.Repositories;
using NLayerBestPratices.Repository.UnitOfWork;
using System.Reflection;
using Module = Autofac.Module;

namespace NLayerBestPratices.Web.Moules
{
    public class RepoSerivceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Services<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            var mvcAssembly = Assembly.GetExecutingAssembly();
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));

            builder.RegisterAssemblyTypes(mvcAssembly, serviceAssembly, repoAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(mvcAssembly, serviceAssembly, repoAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}

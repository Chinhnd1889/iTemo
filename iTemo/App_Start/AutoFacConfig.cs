using Autofac;
using Autofac.Integration.Mvc;
using iTemo.Business.Implementation;
using iTemo.Business.Interface;
using iTemo.Data;
using iTemo.Data.Infrastructure;
using System.Reflection;
using System.Web.Mvc;

namespace iTemo
{
    public static class AutoFacConfig
    {
        private static IContainer _container;

        public static IContainer GetContainer()
        {
            if (_container != null) return _container;

            var builder = new ContainerBuilder();
            // Register MVC controllers.
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.Register(c => new iTemoContext()).As<IEntitiesContext>().InstancePerLifetimeScope();

            #region Register Repository

            builder.RegisterType<iTemoUnitOfWork>().As<IiTemoUnitOfWork>().InstancePerLifetimeScope();

            #endregion

            #region Register Business

            builder.RegisterType<ProductBusiness>().As<IProductBusiness>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryBusiness>().As<ICategoryBusiness>().InstancePerLifetimeScope();
            builder.RegisterType<UserBusiness>().As<IUserBusiness>().InstancePerLifetimeScope();

            #endregion

            _container = builder.Build();
            return _container;
        }

        public static void RegisterContainers()
        {
            DependencyResolver.SetResolver(new AutofacDependencyResolver(GetContainer()));
        }
    }
}
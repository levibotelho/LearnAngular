using System.Reflection;
using System.Web.Mvc;
using AngularTutorial.Repository;
using AngularTutorial.Services;
using AngularTutorial.Web.Dependencies;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;

namespace AngularTutorial.Web
{
    public static class DependencyInjectionConfig
    {
        public static void Register()
        {
            var container = new Container();
            container.RegisterTypes();
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterMvcAttributeFilterProvider();
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        static void RegisterTypes(this Container container)
        {
            container.Register<IUnitOfWork, UnitOfWork>();
            container.Register<ICacheRepository, CacheRepository>();
            container.Register<ICourseService, CourseService>();
            container.Register<ICourseServiceBootstrapper, CourseServiceBootstrapper>();
        }
    }
}
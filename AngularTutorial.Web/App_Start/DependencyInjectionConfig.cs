using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using AngularTutorial.Repository;
using AngularTutorial.Services;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;

namespace AngularTutorial.Web.App_Start
{
    public class DependencyInjectionConfig
    {
        public void Register()
        {
            var container = new Container();
            RegisterTypes(container);
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterMvcAttributeFilterProvider();
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        static void RegisterTypes(Container container)
        {
            container.Register<IUnitOfWorkBootstrapper, UnitOfWorkBootstrapper>();
            container.Register<ICourseRepository, CourseRepository>();
            container.Register<ICourseService, CourseService>();
        }
    }
}
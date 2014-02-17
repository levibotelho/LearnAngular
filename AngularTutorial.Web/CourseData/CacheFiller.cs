using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Hosting;
using AngularTutorial.Entities;
using AngularTutorial.Repository;

namespace AngularTutorial.Web.CourseData
{
    public static class CacheFiller
    {
        static readonly string XmlPath = HostingEnvironment.MapPath(@"~/CourseData/Course.xml");

        [Conditional("FILLCACHE")]
        public static void FillCache()
        {
            var parser = new XmlParser(XmlPath);
            var modules = parser.ParseXml();
            var tableOfContents = new TableOfContents(modules);

            var cacheRepository = DependencyInjectionConfig.DependencyInjectionContainer.GetInstance<ICacheRepository>();
            cacheRepository.Clear();
            cacheRepository.Put(Guid.Parse(ConfigurationFacade.TableOfContentsCacheKey), tableOfContents);
            foreach (var step in modules.SelectMany(x => x.Steps))
                cacheRepository.Put(step.Id, step);
        }
    }
}
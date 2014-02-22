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

        [Conditional("RESETCACHE")]
        public static void FillCache()
        {
            FillCache(XmlPath, DependencyInjectionConfig.DependencyInjectionContainer.GetInstance<ICacheRepository>());
        }

        [Conditional("RESETCACHE")]
        public static void FillCache(string xmlPath, ICacheRepository cacheRepository)
        {
            var parser = new XmlParser(xmlPath);
            var modules = parser.ParseXml();
            var tableOfContents = new TableOfContents(modules);

            cacheRepository.Clear();
            cacheRepository.Put(Guid.Parse(ConfigurationFacade.TableOfContentsCacheKey), tableOfContents);
            foreach (var step in modules.SelectMany(x => x.Steps))
                cacheRepository.Put(step.Id, step);
        }
    }
}
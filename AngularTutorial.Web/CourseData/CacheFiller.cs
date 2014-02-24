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

            // By convention, the table of contents is always situated at Guid.Empty.
            cacheRepository.Put(Guid.Empty, tableOfContents);
            foreach (var lesson in modules.SelectMany(x => x.Lessons))
                cacheRepository.Put(lesson.Id, lesson);
        }
    }
}
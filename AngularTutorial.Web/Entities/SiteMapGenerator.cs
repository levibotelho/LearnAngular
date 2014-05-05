using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using AngularTutorial.Services;

namespace AngularTutorial.Web.Entities
{
    public static class SiteMapGenerator
    {
        const string Host = "http://www.learn-angular.org/#!/";
        const string LessonFragment = "lessons/";

        public static readonly string SitemapPath = HostingEnvironment.MapPath(@"~/Sitemap/Sitemap.txt");

        static readonly string SitemapDirectory = HostingEnvironment.MapPath(@"~/Sitemap/");
        
        static readonly List<string> Urls = new List<string>
        {
            Host,
            Host + "lessons"
        };

        public static void Generate()
        {
            var courseService = DependencyInjectionConfig.DependencyInjectionContainer.GetInstance<ICourseService>();
            var tableOfContents = courseService.GetTableOfContents();
            foreach (var lesson in tableOfContents.Modules.SelectMany(x => x.Children))
            {
                Urls.Add(GenerateLessonUrl(lesson.Id));
            }

            Write();
        }

        static void Write()
        {
            Directory.CreateDirectory(SitemapDirectory);
            // ReSharper disable once AssignNullToNotNullAttribute
            using (var sr = new StreamWriter(SitemapPath))
            {
                foreach (var url in Urls)
                    sr.WriteLine(url);
            }
        }

        static string GenerateLessonUrl(string id)
        {
            return Host + LessonFragment + id;
        }
    }
}
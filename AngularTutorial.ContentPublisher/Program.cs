using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngularTutorial.Repository;
using AngularTutorial.Web.CourseData;
using AngularTutorial.Web.Dependencies;

namespace AngularTutorial.ContentPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            CacheFiller.FillCache(ConfigurationFacade.XmlPath, new CacheRepository(new UnitOfWork()));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngularTutorial.Web.CourseData;

namespace AngularTutorial.ContentPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            CacheFiller.FillCache();
        }
    }
}

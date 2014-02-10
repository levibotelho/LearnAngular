using System;
using AngularTutorial.Services;

namespace AngularTutorial.Web.Dependencies
{
    public class CourseServiceBootstrapper : ICourseServiceBootstrapper
    {
        static Guid _tableOfContentsCacheKey;

        public Guid TableOfContentsCacheKey
        {
            get
            {
                if (_tableOfContentsCacheKey == default(Guid))
                    _tableOfContentsCacheKey = Guid.Parse(ConfigurationFacade.TableOfContentsCacheKey);
                return _tableOfContentsCacheKey;
            }
        }
    }
}
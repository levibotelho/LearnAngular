using System;
using AngularTutorial.Services;

namespace AngularTutorial.SetupCache
{
    public class CourseServiceBootstrapper : ICourseServiceBootstrapper
    {
        public Guid TableOfContentsCacheKey { get { return Guid.Parse(ConfigurationFacade.TableOfContentsCacheKey); } }
    }
}
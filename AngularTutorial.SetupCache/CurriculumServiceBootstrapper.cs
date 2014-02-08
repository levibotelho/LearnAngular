using System;
using AngularTutorial.Services;

namespace AngularTutorial.SetupCache
{
    public class CurriculumServiceBootstrapper : ICurriculumServiceBootstrapper
    {
        public Guid TableOfContentsCacheKey { get { return Guid.Parse(ConfigurationFacade.TableOfContentsCacheKey); } }
    }
}
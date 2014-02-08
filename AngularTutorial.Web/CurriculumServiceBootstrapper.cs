using System;
using AngularTutorial.Services;

namespace AngularTutorial.Web
{
    public class CurriculumServiceBootstrapper : ICurriculumServiceBootstrapper
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
using System;
using AngularTutorial.Repository;

namespace AngularTutorial.Web
{
    public class UnitOfWorkBootstrapper : IUnitOfWorkBootstrapper
    {
        static Guid _tableOfContentsCacheKey;

        public UnitOfWorkBootstrapper()
        {
            if (_tableOfContentsCacheKey == default(Guid))
                _tableOfContentsCacheKey = Guid.Parse(ConfigurationFacade.TableOfContentsCacheKey);

            TableOfContentsCacheKey = _tableOfContentsCacheKey;
        }

        public Guid TableOfContentsCacheKey { get; private set; }
    }
}
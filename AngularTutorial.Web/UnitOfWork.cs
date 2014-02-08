using System;
using AngularTutorial.Repository;
using Microsoft.ApplicationServer.Caching;

namespace AngularTutorial.Web
{
    public class UnitOfWork : IUnitOfWork
    {
        static Guid _tableOfContentsCacheKey;
        static DataCache _cache;

        public Guid TableOfContentsCacheKey
        {
            get
            {
                if (_tableOfContentsCacheKey == default(Guid))
                    _tableOfContentsCacheKey = Guid.Parse(ConfigurationFacade.TableOfContentsCacheKey);
                return _tableOfContentsCacheKey;
            }
        }

        public DataCache Cache
        {
            get
            {
                if (_cache == default(DataCache))
                    _cache = new DataCacheFactory().GetDefaultCache();
                return _cache;
            }
        }
    }
}
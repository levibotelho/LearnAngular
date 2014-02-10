using AngularTutorial.Repository;
using Microsoft.ApplicationServer.Caching;

namespace AngularTutorial.Web.Dependencies
{
    public class UnitOfWork : IUnitOfWork
    {
        static DataCache _cache;

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
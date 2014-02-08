using System;
using Microsoft.ApplicationServer.Caching;

namespace AngularTutorial.Repository
{
    public interface ICacheRepository
    {
        T Get<T>(Guid key);
        void Put(Guid key, object value);
        void Remove(Guid key);
    }

    public class CacheRepository : ICacheRepository
    {
        readonly DataCache _cache;

        public CacheRepository(IUnitOfWork unitOfWork)
        {
            _cache = unitOfWork.Cache;
        }

        public T Get<T>(Guid key)
        {
            return (T)_cache.Get(key.ToString());
        }

        public void Put(Guid key, object value)
        {
            _cache.Put(key.ToString(), value);
        }

        public void Remove(Guid key)
        {
            _cache.Remove(key.ToString());
        }
    }
}
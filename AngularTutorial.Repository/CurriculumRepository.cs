using Microsoft.ApplicationServer.Caching;

namespace AngularTutorial.Repository
{
    public interface ICacheRepository
    {
        T Get<T>(string key);
        void Put(string key, object value);
        void Remove(string key);
    }

    public class CacheRepository : ICacheRepository
    {
        readonly DataCache _cache;

        public CacheRepository(IUnitOfWork unitOfWork)
        {
            _cache = unitOfWork.Cache;
        }


        public T Get<T>(string key)
        {
            return (T)_cache.Get(key);
        }

        public void Put(string key, object value)
        {
            _cache.Put(key, value);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }
    }
}
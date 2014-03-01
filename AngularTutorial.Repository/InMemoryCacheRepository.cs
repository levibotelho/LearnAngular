using System.Collections.Generic;

namespace AngularTutorial.Repository
{
    public interface ICacheRepository
    {
        T Get<T>(string key);
        void Put(string key, object value);
        void Remove(string key);
        void Clear();
    }

    public class InMemoryCacheRepository : ICacheRepository
    {
        static readonly Dictionary<string, object> Cache = new Dictionary<string, object>();

        public T Get<T>(string key)
        {
            return (T)Cache[key];
        }

        public void Put(string key, object value)
        {
            Cache[key] = value;
        }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }

        public void Clear()
        {
            Cache.Clear();
        }
    }
}

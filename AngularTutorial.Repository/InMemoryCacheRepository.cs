using System;
using System.Collections.Generic;

namespace AngularTutorial.Repository
{
    public interface ICacheRepository
    {
        T Get<T>(Guid key);
        void Put(Guid key, object value);
        void Remove(Guid key);
        void Clear();
    }

    public class InMemoryCacheRepository : ICacheRepository
    {
        static readonly Dictionary<Guid, object> Cache = new Dictionary<Guid, object>();

        public T Get<T>(Guid key)
        {
            return (T)Cache[key];
        }

        public void Put(Guid key, object value)
        {
            Cache[key] = value;
        }

        public void Remove(Guid key)
        {
            Cache.Remove(key);
        }

        public void Clear()
        {
            Cache.Clear();
        }
    }
}

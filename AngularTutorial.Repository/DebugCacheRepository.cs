using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularTutorial.Repository
{
    public class DebugCacheRepository : ICacheRepository
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

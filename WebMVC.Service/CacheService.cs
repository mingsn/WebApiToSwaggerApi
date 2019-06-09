using LazyCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC.Service
{
    public class CacheService
    {
        public static CacheService Default { get; private set; }
        private static readonly IAppCache cache;
        static CacheService()
        {
            Default = new CacheService();
            cache = new CachingService();
        }

        public dynamic GetCahce(string key)
        {
            return cache.Get<dynamic>(key);
        }

        public void RemoveCahce(string key)
        {
            cache.Remove(key);
        }

        public dynamic AddCahce(string key, Func<dynamic> CacheFunc)
        {
            return cache.GetOrAdd(key, CacheFunc);
        }

        public bool HasCahce(string key)
        {
            return cache.GetOrAdd<dynamic>(key, () => { return null; }) == null;
        }
    }
}

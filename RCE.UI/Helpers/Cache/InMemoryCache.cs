using System;
using System.Runtime.Caching;

namespace RCE.UI.Helpers
{
    public class InMemoryCache : ICacheService
    {
        /// <summary>
        /// This method help to get data from cache if exist or set data if not exist in cache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <param name="getItemCallback"></param>
        /// <returns></returns>
        public T GetOrSet<T>(string cacheKey, Func<T> getItemCallback) where T : class
        {
            T item = MemoryCache.Default.Get(cacheKey) as T;
            if (item == null)
            {
                item = getItemCallback();
                MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddDays(10));
            }
            return item;
        }
    }
}
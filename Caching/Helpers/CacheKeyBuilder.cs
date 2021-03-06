﻿using System.Linq;

namespace Caching.Helpers
{
    public class CacheKeyBuilder : ICacheKeyBuilder
    {
        public string Build<T>(params string[] args)
        {
            var paramResult = args.Length > 0
                ? args.Aggregate((prev, current) => prev + '_' + current)
                : string.Empty;

            return $"{typeof(T)}_{paramResult}".TrimEnd(' ');
        }
    }
}
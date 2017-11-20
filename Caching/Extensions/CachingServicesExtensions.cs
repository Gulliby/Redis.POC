using Caching.Services;
using Newtonsoft.Json;

namespace Caching.Extensions
{
    public static class CachingServicesExtensions
    {
        private static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        public static void SetValue<T>(this ICachingService cachingService, string key, T value)
        {
            cachingService.SetValue(key, JsonConvert.SerializeObject(value, JsonSettings));
        }

        public static T GetValue<T>(this ICachingService cachingService, string key)
        {
            var resultValue = cachingService.GetValue(key);

            return string.IsNullOrWhiteSpace(resultValue) ? default(T) : JsonConvert.DeserializeObject<T>(resultValue, JsonSettings);
        }
    }
}

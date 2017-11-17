using System.Threading.Tasks;

namespace Caching
{
    public interface ICachingService
    {
        /// <summary>
        /// Set key to hold the string value.
        /// </summary>
        /// <returns>Old value.</returns>
        T SetValue<T>(string key, T value);

        /// <summary>
        /// Get the value of key.
        /// </summary>
        T GetValue<T>(string key);

        /// <summary>
        /// Removes the specified keys. A key is ignored if it does not exist.
        /// </summary>
        /// <returns>The number of keys that were removed.</returns>
        long Delete(params string[] keys);


        /// <summary>
        /// Checks if key exists.
        /// </summary>
        bool IsKeyExists(string key);
    }
}

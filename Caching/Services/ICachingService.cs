namespace Caching.Services
{
    public interface ICachingService
    {
        /// <summary>
        /// Set key to hold the string value.
        /// </summary>
        void SetValue(string key, string value);

        /// <summary>
        /// Get the value of key.
        /// </summary>
        string GetValue(string key);

        /// <summary>
        /// Removes the specified keys. A key is ignored if it does not exist.
        /// </summary>
        void Delete(params string[] keys);
    }
}
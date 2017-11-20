namespace Caching.Helpers
{
    public interface ICacheKeyBuilder
    {
        string Build<T>(params string[] args);
    }
}
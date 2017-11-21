using System.Collections.Generic;
using Caching.Helpers;
using Data.Entities;
using Data.Providers;

namespace Caching.Providers
{
    public class CachedCodesProvider : ICodesProvider
    {
        private readonly ICodesProvider _codesProvider;
        private readonly ICachingProvider _cachingProvider;
        private readonly ICacheKeyBuilder _cacheKeyBuilder;

        public CachedCodesProvider(
            ICodesProvider codesProvider,
            ICachingProvider cachingProvider,
            ICacheKeyBuilder cacheKeyBuilder)
        {
            _codesProvider = codesProvider;
            _cachingProvider = cachingProvider;
            _cacheKeyBuilder = cacheKeyBuilder;
        }

        public void Delete(string codeId)
        {
            RemoveCachedCodeByCodeId(codeId);
            _codesProvider.Delete(codeId);
        }

        public IEnumerable<CodesDb> GetAll()
        {
            return _cachingProvider.GetOrUpdate(_cacheKeyBuilder.Build<CodesDb>(nameof(ICodesProvider.GetAll)), () => _codesProvider.GetAll());
        }

        public CodesDb GetById(string codeId)
        {
            return _cachingProvider.GetOrUpdate(_cacheKeyBuilder.Build<CodesDb>(codeId, nameof(ICodesProvider.GetById)), () => _codesProvider.GetById(codeId));
        }

        public void UpdateCode(CodesDb code)
        {
            RemoveCachedCodeByCodeId(code.CodeId);
            _codesProvider.UpdateCode(code);
        }

        private void RemoveCachedCodeByCodeId(string codeId)
        {
            // Remove all codes from cache and code with codeId.
            _cachingProvider.Remove(_cacheKeyBuilder.Build<CodesDb>(codeId, nameof(ICodesProvider.GetById)));
            _cachingProvider.Remove(_cacheKeyBuilder.Build<CodesDb>(nameof(ICodesProvider.GetAll)));
        }
    }
}

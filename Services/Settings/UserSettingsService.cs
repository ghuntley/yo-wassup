using Akavache;
using Genesis.Ensure;
using ReactiveSearch.Services.Settings;
using Splat;

namespace ReactiveSearch.Services.Connected.Settings
{
    public class UserSettingsService : IUserSettingsService
    {
        private readonly IBlobCache _blobCache;

        public UserSettingsService(IBlobCache blobCache)
        {
            Ensure.ArgumentNotNull(blobCache, nameof(blobCache));

            _blobCache = blobCache;

        }

        public int ExpireSearchResultFromCacheAfter { get; set; }
        //{
        //    get { return this.GetOrCreate(7); }
        //    set { this.SetOrCreate(value); }

        //}
    }
}
namespace ReactiveSearch.Services.Settings
{
    public  interface IUserSettingsService
    {
        int ExpireSearchResultFromCacheAfter { get; }
    }
}
using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using Fusillade;
using Genesis.Ensure;
using ReactiveSearch.Services.Api;
using ReactiveSearch.Services.Search;
using ReactiveSearch.Services.Settings;
using ReactiveSearch.Services.State;

namespace ReactiveSearch.Services.Connected.Search
{
    public class SearchService : ISearchService
    {
        private readonly IDuckDuckGoApiService _duckDuckGoApiService;
        private readonly IScheduler _scheduler;
        private readonly IStateService _stateService;
        private readonly IUserSettingsService _userSettingsService;

        public SearchService(IDuckDuckGoApiService duckDuckGoApiService, IUserSettingsService userSettingsService,
            IScheduler scheduler, IStateService stateService)
        {
            Ensure.ArgumentNotNull(duckDuckGoApiService, nameof(duckDuckGoApiService));
            Ensure.ArgumentNotNull(userSettingsService, nameof(userSettingsService));
            Ensure.ArgumentNotNull(scheduler, nameof(scheduler));
            Ensure.ArgumentNotNull(stateService, nameof(stateService));

            _duckDuckGoApiService = duckDuckGoApiService;
            _userSettingsService = userSettingsService;
            _scheduler = scheduler;
            _stateService = stateService;
        }

        public IObservable<DuckDuckGoSearchResult> RetrieveResultsFromCacheThenSearch(string searchQuery,
            Priority priority)
        {
            return _stateService.GetAndFetchLatest(StateKeys.GetKeyForSearchQuery(searchQuery),
                async () => await ExecuteSearch(searchQuery, priority),
                absoluteExpiration: _scheduler.Now.AddDays(_userSettingsService.ExpireSearchResultFromCacheAfter));
        }

        public IObservable<DuckDuckGoSearchResult> Search(string searchQuery, Priority priority)
        {
            return ExecuteSearch(searchQuery, priority);
        }

        private IObservable<DuckDuckGoSearchResult> ExecuteSearch(string searchQuery, Priority priority)
        {
            switch (priority)
            {
                case Priority.Explicit:
                    return _duckDuckGoApiService.Explicit.Search(searchQuery);

                case Priority.Background:
                    return _duckDuckGoApiService.Background.Search(searchQuery);

                case Priority.Speculative:
                    return _duckDuckGoApiService.Speculative.Search(searchQuery);

                case Priority.UserInitiated:
                    return _duckDuckGoApiService.UserInitiated.Search(searchQuery);

                default:
                    return Observable.Throw<DuckDuckGoSearchResult>(new ArgumentException());
            }
        }
    }
}
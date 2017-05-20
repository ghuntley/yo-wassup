using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using Genesis.Ensure;
using ReactiveSearch.Services.Api;
using ReactiveSearch.Services.NetworkConnectivity;
using ReactiveSearch.Services.Search;
using ReactiveUI;

namespace ReactiveSearch.Core.Features.Search
{
    public class SearchViewModel : ReactiveObject
    {
        private readonly INetworkConnectivityService _networkConnectivityService;
        private readonly IScheduler _scheduler;
        private readonly ISearchService _searchService;

        public SearchViewModel(INetworkConnectivityService networkConnectivityService, ISearchService searchService,
            IScheduler scheduler)
        {
            Ensure.ArgumentNotNull(networkConnectivityService, nameof(networkConnectivityService));
            Ensure.ArgumentNotNull(searchService, nameof(searchService));
            Ensure.ArgumentNotNull(scheduler, nameof(scheduler));

            _networkConnectivityService = networkConnectivityService;
            _searchService = searchService;
            _scheduler = scheduler;

            SearchResults = new ReactiveList<SearchViewModel>();

            // Here we're describing here, in a *declarative way*, the conditions in
            // which the Search command is enabled.  Now our Command IsEnabled is
            // perfectly efficient, because we're only updating the UI in the scenario
            // when it should change.
            var canSearch = this.WhenAnyValue<SearchViewModel, bool, string>(viewModel => viewModel.SearchQuery,
                value => !string.IsNullOrWhiteSpace(value));

            // ReactiveCommand has built-in support for background operations and
            // guarantees that this block will only run exactly once at a time, and
            // that the CanExecute will auto-disable and that property IsExecuting will
            // be set according whilst it is running.
            Search =
                ReactiveCommand.CreateFromObservable<string, IEnumerable<DuckDuckGoSearchResult>>(
                    _ => _searchService.RetrieveResultsFromCacheThenSearch(SearchQuery), canSearch);

            // ReactiveCommands are themselves IObservables, whose value are the results
            // from the async method, guaranteed to arrive on the UI thread. We're going
            // to take the list of search results that the background operation loaded,
            // and them into our SearchResults.

            // this is .OnNext and .OnCompleted
            Search.Subscribe(results =>
            {
                using (SearchResults.SuppressChangeNotifications())
                {
                    //SearchResults.Clear();
                    //SearchResults.AddRange(results);
                }
            });

            // ThrownExceptions is any exception thrown from the CreateAsyncTask piped
            // to this Observable. Subscribing to this allows you to handle errors on
            // the UI thread.

            // this is .OnError
            Search.ThrownExceptions
                .Subscribe(ex => { });

            // Whenever the Search query changes, we're going to wait for one second
            // of "dead airtime", then automatically invoke the subscribe command.
            this.WhenAnyValue(x => x.SearchQuery)
                .Throttle(TimeSpan.FromSeconds(1), _scheduler)
                .InvokeCommand(this, x => x.Search);
        }

        [Reactive]
        public string SearchQuery { get; set; }

        public ReactiveCommand<string, IEnumerable<DuckDuckGoSearchResult>> Search { get; }

        public ReactiveList<SearchViewModel> SearchResults { get; }
    }
}
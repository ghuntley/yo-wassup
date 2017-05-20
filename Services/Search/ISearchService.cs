using System;
using Fusillade;
using ReactiveSearch.Services.Api;

namespace ReactiveSearch.Services.Search
{
    public interface ISearchService
    {
        IObservable<DuckDuckGoSearchResult> RetrieveResultsFromCacheThenSearch(string searchQuery, Priority priority);

        IObservable<DuckDuckGoSearchResult> Search(string searchQuery, Priority priority);
    }
}
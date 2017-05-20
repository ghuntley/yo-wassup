using System;
using Refit;

namespace ReactiveSearch.Services.Api
{
    public interface IDuckDuckGoApi
    {
        [Get("/?q={searchQuery}&format=json")]
        IObservable<DuckDuckGoSearchResult> Search(string searchQuery);
    }
}
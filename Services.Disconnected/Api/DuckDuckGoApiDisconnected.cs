using System;
using System.Reactive;
using System.Reactive.Linq;
using Newtonsoft.Json;
using ReactiveSearch.Services.Api;

namespace ReactiveSearch.Services.Disconnected.Api
{
    public class DuckDuckGoApiDisconnected : IDuckDuckGoApi
    {
        private readonly bool _enableRandomDelays;
        private readonly bool _enableRandomErrors;
        private readonly DuckDuckGoSearchResult _searchResult;

        public DuckDuckGoApiDisconnected(bool enableRandomDelays, bool enableRandomErrors)
        {
            _enableRandomDelays = enableRandomDelays;
            _enableRandomErrors = enableRandomErrors;
            _searchResult =
                JsonConvert.DeserializeObject<DuckDuckGoSearchResult>(DuckDuckGoApiDisconnectedResponses.Search);
        }

        public IObservable<DuckDuckGoSearchResult> Search(string searchQuery)
        {
            return Observable.Return(_searchResult)
                .ErrorWithProbabilityIf(_enableRandomErrors, 5)
                .DelayIf(_enableRandomDelays, 500, 1000);
        }
    }
}
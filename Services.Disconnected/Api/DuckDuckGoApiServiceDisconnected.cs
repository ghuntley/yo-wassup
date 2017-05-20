using ReactiveSearch.Services.Api;

namespace ReactiveSearch.Services.Disconnected.Api
{
    public class DuckDuckGoApiServiceDisconnected : IDuckDuckGoApiService
    {
        public DuckDuckGoApiServiceDisconnected(bool enableRandomDelays, bool enableRandomErrors)
        {
            Background = new DuckDuckGoApiDisconnected(enableRandomDelays, enableRandomErrors);
            Explicit = new DuckDuckGoApiDisconnected(enableRandomDelays, enableRandomErrors);
            Speculative = new DuckDuckGoApiDisconnected(enableRandomDelays, enableRandomErrors);
            UserInitiated = new DuckDuckGoApiDisconnected(enableRandomDelays, enableRandomErrors);
        }

        public IDuckDuckGoApi Background { get; }
        public IDuckDuckGoApi Explicit { get; }
        public IDuckDuckGoApi Speculative { get; }
        public IDuckDuckGoApi UserInitiated { get; }
    }
}
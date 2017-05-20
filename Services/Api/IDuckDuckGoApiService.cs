namespace ReactiveSearch.Services.Api
{
    public interface IDuckDuckGoApiService
    {
        IDuckDuckGoApi Background { get; }
        IDuckDuckGoApi Speculative { get; }
        IDuckDuckGoApi UserInitiated { get; }
        IDuckDuckGoApi Explicit { get; }
    }
}
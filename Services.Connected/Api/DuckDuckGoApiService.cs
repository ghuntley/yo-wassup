﻿using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Fusillade;
using HttpClientDiagnostics;
using ReactiveSearch.Services.Api;
using Refit;

namespace ReactiveSearch.Services.Connected.Api
{
    public class DuckDuckGoApiService : IDuckDuckGoApiService
    {
        private const string DefaultApiBaseAddress = "https://api.duckduckgo.com";

        private readonly Lazy<IDuckDuckGoApi> _background;
        private readonly Lazy<IDuckDuckGoApi> _explicit;
        private readonly Lazy<IDuckDuckGoApi> _speculative;
        private readonly Lazy<IDuckDuckGoApi> _userInitiated;

        public DuckDuckGoApiService(string apiBaseAddress = null, bool enableDiagnostics = false)
        {
            Func<HttpMessageHandler, IDuckDuckGoApi> createClient = innerHandler =>
            {
                var handler = enableDiagnostics ? new HttpClientDiagnosticsHandler(innerHandler) : innerHandler;

                var client = new HttpClient(handler)
                {
                    BaseAddress = new Uri(apiBaseAddress ?? DefaultApiBaseAddress)
                };
                return RestService.For<IDuckDuckGoApi>(client);
            };

            _background = new Lazy<IDuckDuckGoApi>(() => createClient(
                new RateLimitedHttpMessageHandler(new DummyHandler(), Priority.Background)));

            _explicit = new Lazy<IDuckDuckGoApi>(() => createClient(
                new RateLimitedHttpMessageHandler(new DummyHandler(), Priority.Explicit)));

            _userInitiated = new Lazy<IDuckDuckGoApi>(() => createClient(
                new RateLimitedHttpMessageHandler(new DummyHandler(), Priority.UserInitiated)));

            _speculative = new Lazy<IDuckDuckGoApi>(() => createClient(
                new RateLimitedHttpMessageHandler(new DummyHandler(), Priority.Speculative)));
        }

        public IDuckDuckGoApi Background => _background.Value;

        public IDuckDuckGoApi Explicit => _explicit.Value;

        public IDuckDuckGoApi Speculative => _speculative.Value;
        public IDuckDuckGoApi UserInitiated => _userInitiated.Value;
    }

    public class DummyHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken);
        }
    }
}
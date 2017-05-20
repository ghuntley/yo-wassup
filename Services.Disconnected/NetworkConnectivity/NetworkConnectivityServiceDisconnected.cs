using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using Plugin.Connectivity.Abstractions;
using ReactiveSearch.Services.NetworkConnectivity;

namespace ReactiveSearch.Services.Disconnected.NetworkConnectivity
{
    public class NetworkConnectivityServiceDisconnected : INetworkConnectivityService
    {
        private readonly bool _enableRandomDelays;
        private readonly bool _enableRandomErrors;

        private readonly IEnumerable<ConnectionType> _networkConnectivity = new List<ConnectionType>
        {
            ConnectionType.Cellular,
            ConnectionType.WiFi
        };

        public NetworkConnectivityServiceDisconnected(bool enableRandomDelays, bool enableRandomErrors)
        {
            _enableRandomDelays = enableRandomDelays;
            _enableRandomErrors = enableRandomErrors;
        }

        public IObservable<bool> IsInternetConnectivityAvailable()
        {
            return Observable.Return(true)
                .ErrorWithProbabilityIf(_enableRandomErrors, 5)
                .DelayIf(_enableRandomDelays, 500, 1000);
        }

        public IObservable<bool> IsReachable(string host, int port = 80, int msTimeout = 5000)
        {
            return Observable.Return(true)
                .ErrorWithProbabilityIf(_enableRandomErrors, 5)
                .DelayIf(_enableRandomDelays, 500, 1000);
        }

        public IObservable<IEnumerable<ConnectionType>> InternetConnectivity()
        {
            return Observable.Return(_networkConnectivity)
                .ErrorWithProbabilityIf(_enableRandomErrors, 5)
                .DelayIf(_enableRandomDelays, 500, 1000);
        }
    }
}
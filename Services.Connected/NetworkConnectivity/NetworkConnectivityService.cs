using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive.Threading.Tasks;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using ReactiveSearch.Services.NetworkConnectivity;
using ReactiveSearch.Utility;

namespace ReactiveSearch.Services.Connected.NetworkConnectivity
{
    public class NetworkConnectivityService : DisposableBase, INetworkConnectivityService
    {
        private readonly ReplaySubject<IEnumerable<ConnectionType>> _internetConnection;
        private readonly ReplaySubject<bool> _isInternetConnectivityAvailable;

        public NetworkConnectivityService()
        {
            _isInternetConnectivityAvailable = new ReplaySubject<bool>(1);
            _internetConnection = new ReplaySubject<IEnumerable<ConnectionType>>(1);

            CrossConnectivity.Current.ConnectivityChanged += OnConnectivityChanged;
        }

        public IObservable<IEnumerable<ConnectionType>> InternetConnectivity()
        {
            return _internetConnection.AsObservable();
        }

        public IObservable<bool> IsInternetConnectivityAvailable()
        {
            return _isInternetConnectivityAvailable.AsObservable();
        }

        public IObservable<bool> IsReachable(string host, int port = 80, int msTimeout = 5000)
        {
            return CrossConnectivity.Current.IsRemoteReachable(host, port, msTimeout).ToObservable();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                CrossConnectivity.Current.ConnectivityChanged -= OnConnectivityChanged;
            }
        }

        private void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            _isInternetConnectivityAvailable.OnNext(CrossConnectivity.Current.IsConnected);
            _internetConnection.OnNext(CrossConnectivity.Current.ConnectionTypes);
        }
    }
}
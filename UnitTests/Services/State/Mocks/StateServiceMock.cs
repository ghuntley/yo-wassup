using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;
using PCLMock;
using ReactiveSearch.Services.Api;
using ReactiveSearch.Services.State;

namespace ReactiveSearch.UnitTests.Services.State.Mocks
{
    public sealed class StateServiceMock : MockBase<IStateService>, IStateService
    {
        public StateServiceMock(MockBehavior behavior = MockBehavior.Strict)
            : base(behavior)
        {
        }

        public IObservable<T> Get<T>(string key)
        {
            return Apply(x => x.Get<T>(key));
        }

        public IObservable<T> GetOrFetch<T>(string key, Func<Task<T>> fetchFunc,
            DateTimeOffset? absoluteExpiration = default(DateTimeOffset?))
        {
            return Apply(x => x.GetOrFetch(key, fetchFunc, absoluteExpiration));
        }

        public IObservable<Unit> Invalidate(string key)
        {
            return Apply(x => x.Invalidate(key));
        }

        public IDisposable RegisterSaveCallback(SaveCallback saveCallback)
        {
            return Apply(x => x.RegisterSaveCallback(saveCallback));
        }

        public IObservable<Unit> Remove<T>(string key)
        {
            return Apply(x => x.Remove<T>(key));
        }

        public IObservable<Unit> Save()
        {
            return Apply(x => x.Save());
        }

        public IObservable<Unit> Set<T>(string key, T value)
        {
            return Apply(x => x.Set(key, value));
        }

        public IObservable<Unit> Set<T>(string key, T value, TimeSpan expiration)
        {
            return Apply(x => x.Set(key, value, expiration));
        }


        public void ConfigureLooseBehavior()
        {
            When(x => x.Save())
                .Return(Observable.Return(Unit.Default));
            When(x => x.RegisterSaveCallback(It.IsAny<SaveCallback>()))
                .Return(Disposable.Empty);
        }

        public IObservable<T> GetAndFetchLatest<T>(string key, IObservable<DuckDuckGoSearchResult> fetchFunc,
            Func<DateTimeOffset, bool> fetchPredicate = null, DateTimeOffset? absoluteExpiration = null)
        {
            return this.Apply(x => x.GetAndFetchLatest<T>(key, fetchFunc, fetchPredicate, absoluteExpiration));
        }
    }
}
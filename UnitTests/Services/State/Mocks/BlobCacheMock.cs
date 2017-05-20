using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Concurrency;
using Akavache;
using PCLMock;

namespace ReactiveSearch.UnitTests.Services.State.Mocks
{
    public sealed class BlobCacheMock : MockBase<IBlobCache>, IBlobCache
    {
        public BlobCacheMock(MockBehavior behavior = MockBehavior.Strict)
            : base(behavior)
        {
        }

        public IObservable<Unit> Shutdown => Apply(x => x.Shutdown);

        public IScheduler Scheduler => Apply(x => x.Scheduler);

        public IObservable<Unit> Insert(string key, byte[] data,
            DateTimeOffset? absoluteExpiration = default(DateTimeOffset?)) =>
            Apply(x => x.Insert(key, data, absoluteExpiration));

        public IObservable<byte[]> Get(string key) =>
            Apply(x => x.Get(key));

        public IObservable<IEnumerable<string>> GetAllKeys() =>
            Apply(x => x.GetAllKeys());

        public IObservable<DateTimeOffset?> GetCreatedAt(string key) =>
            Apply(x => x.GetCreatedAt(key));

        public IObservable<Unit> Flush() =>
            Apply(x => x.Flush());

        public IObservable<Unit> Invalidate(string key) =>
            Apply(x => x.Invalidate(key));

        public IObservable<Unit> InvalidateAll() =>
            Apply(x => x.InvalidateAll());

        public IObservable<Unit> Vacuum() =>
            Apply(x => x.Vacuum());

        public void Dispose() =>
            Apply(x => x.Dispose());
    }
}
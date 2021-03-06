﻿using System;
using System.Linq;
using ReactiveSearch.App;
using ReactiveSearch.Services.Api;
using ReactiveSearch.Services.Connected.Api;
using ReactiveSearch.Services.Connected.State;

namespace Conventions
{
    public class BaseFixture
    {
        public readonly Type[] ApplicationAssemblies =
        {
            // app
            typeof(CompositionRoot)
        };

        public readonly Type[] CoreAssemblies =
        {
            // core
            typeof(BlobCacheKeys)
        };

        public readonly Type[] ServiceAssemblies =
        {
            // services
            typeof(IDuckDuckGoApiService),

            // connected
            typeof(DuckDuckGoApiService),

            // disconnected
            typeof(StateService)
        };

        public Type[] AllAssemblies => ConcatArrays(ApplicationAssemblies, CoreAssemblies, ServiceAssemblies);

        private static T[] ConcatArrays<T>(params T[][] list)
        {
            var result = new T[list.Sum(a => a.Length)];
            var offset = 0;
            for (var x = 0; x < list.Length; x++)
            {
                list[x].CopyTo(result, offset);
                offset += list[x].Length;
            }
            return result;
        }
    }
}
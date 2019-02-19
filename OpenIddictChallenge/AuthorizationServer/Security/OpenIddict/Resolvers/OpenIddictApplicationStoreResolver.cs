using OpenIddict.Abstractions;
using SRPIntranet.Security;
using System;
using System.Collections.Concurrent;
using Microsoft.Extensions.DependencyInjection;
using SRPIntranet.Security.OpenIddict.Models;
using SRPIntranet.Security.OpenIddict.Stores;

namespace SRPIntranet.Security.OpenIddict.Resolvers
{
    public class OpenIddictApplicationStoreResolver : IOpenIddictApplicationStoreResolver
    {
        private readonly ConcurrentDictionary<Type, Type> _cache = new ConcurrentDictionary<Type, Type>();
        private readonly IServiceProvider _provider;

        public IOpenIddictApplicationStore<TApplication> Get<TApplication>() where TApplication : class
        {
            var store = _provider.GetService<IOpenIddictApplicationStore<TApplication>>();
            if (store != null)
            {
                return store;
            }

            var type = _cache.GetOrAdd(typeof(TApplication), key =>
            {
                if (!typeof(OpenIddictApplication).IsAssignableFrom(key))
                {
                    throw new InvalidOperationException("ERREUR");
                }

                return typeof(OpenIddictApplicationStore<>).MakeGenericType(key);
            });

            return (IOpenIddictApplicationStore<TApplication>)_provider.GetRequiredService(type);
        }
    }
}

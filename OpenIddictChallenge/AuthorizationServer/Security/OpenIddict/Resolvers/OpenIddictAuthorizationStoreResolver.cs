using OpenIddict.Abstractions;
using SRPIntranet.Security;
using System;
using System.Collections.Concurrent;
using Microsoft.Extensions.DependencyInjection;
using SRPIntranet.Security.OpenIddict.Models;
using SRPIntranet.Security.OpenIddict.Stores;

namespace SRPIntranet.Security.OpenIddict.Resolvers
{
    public class OpenIddictAuthorizationStoreResolver : IOpenIddictAuthorizationStoreResolver
    {
        private readonly ConcurrentDictionary<Type, Type> _cache = new ConcurrentDictionary<Type, Type>();
        private readonly IServiceProvider _provider;

        public IOpenIddictAuthorizationStore<TAuthorization> Get<TAuthorization>() where TAuthorization : class
        {
            var store = _provider.GetService<IOpenIddictAuthorizationStore<TAuthorization>>();
            if (store != null)
            {
                return store;
            }

            var type = _cache.GetOrAdd(typeof(TAuthorization), key =>
            {
                if (!typeof(OpenIddictAuthorization).IsAssignableFrom(key))
                {
                    throw new InvalidOperationException("ERREUR");
                }

                return typeof(OpenIddictAuthorizationStore<>).MakeGenericType(key);
            });

            return (IOpenIddictAuthorizationStore<TAuthorization>)_provider.GetRequiredService(type);
        }
    }
}

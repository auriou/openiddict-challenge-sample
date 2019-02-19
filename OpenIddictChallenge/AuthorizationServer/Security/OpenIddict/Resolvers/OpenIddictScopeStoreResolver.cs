using OpenIddict.Abstractions;
using SRPIntranet.Security;
using System;
using System.Collections.Concurrent;
using Microsoft.Extensions.DependencyInjection;
using SRPIntranet.Security.OpenIddict.Models;
using SRPIntranet.Security.OpenIddict.Stores;

namespace SRPIntranet.Security.OpenIddict.Resolvers
{
    public class OpenIddictScopeStoreResolver : IOpenIddictScopeStoreResolver
    {
        private readonly ConcurrentDictionary<Type, Type> _cache = new ConcurrentDictionary<Type, Type>();
        private readonly IServiceProvider _provider;
        public IOpenIddictScopeStore<TScope> Get<TScope>() where TScope : class
        {
            var store = _provider.GetService<IOpenIddictScopeStore<TScope>>();
            if (store != null)
            {
                return store;
            }

            var type = _cache.GetOrAdd(typeof(TScope), key =>
            {
                if (!typeof(OpenIddictScope).IsAssignableFrom(key))
                {
                    throw new InvalidOperationException("ERREUR");
                }

                return typeof(OpenIddictScopeStore<>).MakeGenericType(key);
            });

            return (IOpenIddictScopeStore<TScope>)_provider.GetRequiredService(type);
        }
    }
}

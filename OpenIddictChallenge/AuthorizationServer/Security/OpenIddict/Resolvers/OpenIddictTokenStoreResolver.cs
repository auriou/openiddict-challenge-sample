using OpenIddict.Abstractions;
using SRPIntranet.Security;
using System;
using System.Collections.Concurrent;
using Microsoft.Extensions.DependencyInjection;
using SRPIntranet.Security.OpenIddict.Models;
using SRPIntranet.Security.OpenIddict.Stores;

namespace SRPIntranet.Security.OpenIddict.Resolvers
{
    public class OpenIddictTokenStoreResolver : IOpenIddictTokenStoreResolver
    {
        private readonly ConcurrentDictionary<Type, Type> _cache = new ConcurrentDictionary<Type, Type>();
        private readonly IServiceProvider _provider;

        /// <summary>
        /// Returns a token store compatible with the specified token type or throws an
        /// <see cref="InvalidOperationException"/> if no store can be built using the specified type.
        /// </summary>
        /// <typeparam name="TToken">The type of the Token entity.</typeparam>
        /// <returns>An <see cref="IOpenIddictTokenStore{TToken}"/>.</returns>
        public IOpenIddictTokenStore<TToken> Get<TToken>() where TToken : class
        {
            var store = _provider.GetService<IOpenIddictTokenStore<TToken>>();
            if (store != null)
            {
                return store;
            }

            var type = _cache.GetOrAdd(typeof(TToken), key =>
            {
                if (!typeof(OpenIddictToken).IsAssignableFrom(key))
                {
                    throw new InvalidOperationException("ERREUR");
                }

                return typeof(OpenIddictTokenStore<>).MakeGenericType(key);
            });

            return (IOpenIddictTokenStore<TToken>)_provider.GetRequiredService(type);
        }
    }
}

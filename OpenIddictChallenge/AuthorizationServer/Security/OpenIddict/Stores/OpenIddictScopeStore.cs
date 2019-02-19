using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using OpenIddict.Abstractions;
using SRPIntranet.Security;
using SRPIntranet.Security.OpenIddict.Models;

namespace SRPIntranet.Security.OpenIddict.Stores
{
    public class OpenIddictScopeStore<TScope> : IOpenIddictScopeStore<TScope>
    where TScope : OpenIddictScope
    {
        public Task<long> CountAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<long> CountAsync<TResult>(System.Func<IQueryable<TScope>, IQueryable<TResult>> query, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateAsync(TScope scope, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(TScope scope, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<TScope> FindByIdAsync(string identifier, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<TScope> FindByNameAsync(string name, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<ImmutableArray<TScope>> FindByNamesAsync(ImmutableArray<string> names, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<ImmutableArray<TScope>> FindByResourceAsync(string resource, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<TResult> GetAsync<TState, TResult>(System.Func<IQueryable<TScope>, TState, IQueryable<TResult>> query, TState state, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public ValueTask<string> GetDescriptionAsync(TScope scope, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public ValueTask<string> GetDisplayNameAsync(TScope scope, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public ValueTask<string> GetIdAsync(TScope scope, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public ValueTask<string> GetNameAsync(TScope scope, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public ValueTask<JObject> GetPropertiesAsync(TScope scope, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public ValueTask<ImmutableArray<string>> GetResourcesAsync(TScope scope, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public ValueTask<TScope> InstantiateAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<ImmutableArray<TScope>> ListAsync(int? count, int? offset, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<ImmutableArray<TResult>> ListAsync<TState, TResult>(System.Func<IQueryable<TScope>, TState, IQueryable<TResult>> query, TState state, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task SetDescriptionAsync(TScope scope, string description, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task SetDisplayNameAsync(TScope scope, string name, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task SetNameAsync(TScope scope, string name, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task SetPropertiesAsync(TScope scope, JObject properties, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task SetResourcesAsync(TScope scope, ImmutableArray<string> resources, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(TScope scope, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}

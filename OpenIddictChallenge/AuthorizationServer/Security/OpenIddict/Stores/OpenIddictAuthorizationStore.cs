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
    public class OpenIddictAuthorizationStore<TAuthorization> : IOpenIddictAuthorizationStore<TAuthorization>
        where TAuthorization : OpenIddictAuthorization
    {
        public Task<long> CountAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<long> CountAsync<TResult>(System.Func<IQueryable<TAuthorization>, IQueryable<TResult>> query, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateAsync(TAuthorization authorization, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(TAuthorization authorization, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<ImmutableArray<TAuthorization>> FindAsync(string subject, string client, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<ImmutableArray<TAuthorization>> FindAsync(string subject, string client, string status, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<ImmutableArray<TAuthorization>> FindAsync(string subject, string client, string status, string type, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<ImmutableArray<TAuthorization>> FindAsync(string subject, string client, string status, string type, ImmutableArray<string> scopes, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<ImmutableArray<TAuthorization>> FindByApplicationIdAsync(string identifier, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<TAuthorization> FindByIdAsync(string identifier, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<ImmutableArray<TAuthorization>> FindBySubjectAsync(string subject, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public ValueTask<string> GetApplicationIdAsync(TAuthorization authorization, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<TResult> GetAsync<TState, TResult>(System.Func<IQueryable<TAuthorization>, TState, IQueryable<TResult>> query, TState state, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public ValueTask<string> GetIdAsync(TAuthorization authorization, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public ValueTask<JObject> GetPropertiesAsync(TAuthorization authorization, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public ValueTask<ImmutableArray<string>> GetScopesAsync(TAuthorization authorization, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public ValueTask<string> GetStatusAsync(TAuthorization authorization, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public ValueTask<string> GetSubjectAsync(TAuthorization authorization, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public ValueTask<string> GetTypeAsync(TAuthorization authorization, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public ValueTask<TAuthorization> InstantiateAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<ImmutableArray<TAuthorization>> ListAsync(int? count, int? offset, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<ImmutableArray<TResult>> ListAsync<TState, TResult>(System.Func<IQueryable<TAuthorization>, TState, IQueryable<TResult>> query, TState state, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task PruneAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task SetApplicationIdAsync(TAuthorization authorization, string identifier, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task SetPropertiesAsync(TAuthorization authorization, JObject properties, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task SetScopesAsync(TAuthorization authorization, ImmutableArray<string> scopes, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task SetStatusAsync(TAuthorization authorization, string status, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task SetSubjectAsync(TAuthorization authorization, string subject, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task SetTypeAsync(TAuthorization authorization, string type, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(TAuthorization authorization, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}

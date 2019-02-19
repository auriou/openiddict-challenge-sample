using System;
using System.Diagnostics;

namespace SRPIntranet.Security.OpenIddict.Models
{
    [DebuggerDisplay("Id = {Id.ToString(),nq} ; ClientId = {ClientId,nq} ; Type = {Type,nq}")]
    public class OpenIddictApplication
    {
        public virtual string ClientId { get; set; }
        public virtual string ClientSecret { get; set; }
        public virtual string ConcurrencyToken { get; set; } = Guid.NewGuid().ToString();
        public virtual string ConsentType { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual Guid Id { get; set; }
        public virtual string[] Permissions { get; set; } = Array.Empty<string>();
        public virtual string[] PostLogoutRedirectUris { get; set; } = Array.Empty<string>();
        public virtual string Properties { get; set; }
        public virtual string[] RedirectUris { get; set; } = Array.Empty<string>();
        public virtual string Type { get; set; }
    }
}
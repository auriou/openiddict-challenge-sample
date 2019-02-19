using System;
using System.Diagnostics;

namespace SRPIntranet.Security.OpenIddict.Models
{
    /// <summary>
    /// Represents an OpenIddict authorization.
    /// </summary>
    [DebuggerDisplay("Id = {Id.ToString(),nq} ; Subject = {Subject,nq} ; Type = {Type,nq} ; Status = {Status,nq}")]
    public class OpenIddictAuthorization
    {
        public virtual string ConcurrencyToken { get; set; } = Guid.NewGuid().ToString();
        public virtual Guid Id { get; set; }
        public virtual string Properties { get; set; }
        public virtual string[] Scopes { get; set; } = Array.Empty<string>();
        public virtual string Status { get; set; }
        public virtual string Subject { get; set; }
        public virtual string Type { get; set; }
    }
}

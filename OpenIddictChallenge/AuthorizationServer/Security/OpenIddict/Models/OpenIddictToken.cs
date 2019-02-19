using System;
using System.Diagnostics;

namespace SRPIntranet.Security.OpenIddict.Models
{
    /// <summary>
    /// Represents an OpenIddict token.
    /// </summary>
    [DebuggerDisplay("Id = {Id.ToString(),nq} ; Subject = {Subject,nq} ; Type = {Type,nq} ; Status = {Status,nq}")]
    public class OpenIddictToken
    {
        public virtual Guid ApplicationId { get; set; }
        public virtual Guid AuthorizationId { get; set; }
        public virtual string ConcurrencyToken { get; set; } = Guid.NewGuid().ToString();
        public virtual DateTime? CreationDate { get; set; }
        public virtual DateTime? ExpirationDate { get; set; }
        public virtual Guid Id { get; set; }
        public virtual string Payload { get; set; }
        public virtual string Properties { get; set; }
        public virtual string ReferenceId { get; set; }
        public virtual string Status { get; set; }
        public virtual string Subject { get; set; }
        public virtual string Type { get; set; }
    }
}

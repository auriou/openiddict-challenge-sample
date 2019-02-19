using System;
using System.Diagnostics;

namespace SRPIntranet.Security.OpenIddict.Models
{
    /// <summary>
    /// Represents an OpenIddict scope.
    /// </summary>
    [DebuggerDisplay("Id = {Id.ToString(),nq} ; Name = {Name,nq}")]
    public class OpenIddictScope
    {
        public virtual string ConcurrencyToken { get; set; } = Guid.NewGuid().ToString();
        public virtual string Description { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Properties { get; set; }
        public virtual string[] Resources { get; set; } = Array.Empty<string>();
    }
}

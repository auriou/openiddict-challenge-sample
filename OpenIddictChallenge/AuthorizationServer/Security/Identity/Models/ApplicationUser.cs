using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace SRPIntranet.Security.Identity.Models
{
    /*IIdentity*/
    public class ApplicationUser : IdentityUser
    {
        //public virtual Guid Id { get; set; } = Guid.NewGuid();
        //public virtual string UserName { get; set; }
        //public virtual string Email { get; set; }
        //public virtual bool EmailConfirmed { get; set; }
        //public virtual String PasswordHash { get; set; }
        //public string NormalizedUserName { get; internal set; }
        public string AuthenticationType { get; set; }
        public bool IsAuthenticated { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login
        {
            get { return this.UserName; }
            set { this.UserName = value; }
        }
        public string Role { get; set; }
        public string Profil { get; set; }
        public string Functions { get; set; }
        public string Salt { get; set; }
        public string Hash
        {
            get { return this.PasswordHash; }
            set { this.PasswordHash = value; }
        }
    }
}

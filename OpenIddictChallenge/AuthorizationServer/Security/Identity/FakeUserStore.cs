using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System.Security.Claims;
using SRPIntranet.Security.Identity.Models;

namespace SRPIntranet.Security.Identity
{

    public class FakeUserStore : 
        IUserStore<ApplicationUser>, 
        IUserPasswordStore<ApplicationUser>,
        IUserClaimStore<ApplicationUser>,
        IUserRoleStore<ApplicationUser>
    {

        private ApplicationUser _user = new ApplicationUser
        {
            Email = "p.auriou@gmail.com",
            Login = "pau",
            FirstName = "Philippe",
            LastName = "AURIOU",
            Id = "123"
        };

        public FakeUserStore()
        {

        }

        #region method

        Task<string> IUserPasswordStore<ApplicationUser>.GetPasswordHashAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash);
        }

        Task<string> IUserStore<ApplicationUser>.GetUserIdAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        Task<string> IUserStore<ApplicationUser>.GetUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName);
        }
        Task<IList<Claim>> IUserClaimStore<ApplicationUser>.GetClaimsAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            IList<Claim> res = new List<Claim>();
            return Task.FromResult(res);
        }

        Task<IList<string>> IUserRoleStore<ApplicationUser>.GetRolesAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            IList<string> res = new List<string>();
            if (!string.IsNullOrEmpty(user.Role)) res.Add(user.Role);
            if (!string.IsNullOrEmpty(user.Profil)) res.Add(user.Profil);
            return Task.FromResult(res);
        }

        Task<ApplicationUser> IUserStore<ApplicationUser>.FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            return Task.FromResult(_user);
        }

        Task<ApplicationUser> IUserStore<ApplicationUser>.FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return Task.FromResult(_user);
        }

        public Task<IList<string>> GetRolesAsync(ApplicationRole user, CancellationToken cancellationToken)
        {
            IList<string> res = new List<string>() ;
            return Task.FromResult(res);
        }

        void IDisposable.Dispose()
        {
        }

        #endregion

        #region not implemented
        Task IUserClaimStore<ApplicationUser>.AddClaimsAsync(ApplicationUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task IUserRoleStore<ApplicationUser>.AddToRoleAsync(ApplicationUser user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<IdentityResult> IUserStore<ApplicationUser>.CreateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<IdentityResult> IUserStore<ApplicationUser>.DeleteAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<string> IUserStore<ApplicationUser>.GetNormalizedUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<IList<ApplicationUser>> IUserClaimStore<ApplicationUser>.GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<IList<ApplicationUser>> IUserRoleStore<ApplicationUser>.GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<bool> IUserPasswordStore<ApplicationUser>.HasPasswordAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<bool> IUserRoleStore<ApplicationUser>.IsInRoleAsync(ApplicationUser user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task IUserClaimStore<ApplicationUser>.RemoveClaimsAsync(ApplicationUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task IUserRoleStore<ApplicationUser>.RemoveFromRoleAsync(ApplicationUser user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task IUserClaimStore<ApplicationUser>.ReplaceClaimAsync(ApplicationUser user, Claim claim, Claim newClaim, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task IUserStore<ApplicationUser>.SetNormalizedUserNameAsync(ApplicationUser user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task IUserPasswordStore<ApplicationUser>.SetPasswordHashAsync(ApplicationUser user, string passwordHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task IUserStore<ApplicationUser>.SetUserNameAsync(ApplicationUser user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<IdentityResult> IUserStore<ApplicationUser>.UpdateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion
       

    }
}

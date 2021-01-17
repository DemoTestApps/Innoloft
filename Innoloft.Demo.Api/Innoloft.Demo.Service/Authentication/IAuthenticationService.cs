using Innoloft.Demo.Core.Entity.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Innoloft.Demo.Service.Authentication
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResult> AuthenticateUser(User user);

        Task<User> GetUserByClaimPrinciple(ClaimsPrincipal principal);

        Task<User> GetUserByUserName(string userName);
    }
}

using Microsoft.AspNetCore.Identity;
using Innoloft.Demo.Core.Entity.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Innoloft.Demo.Service.Users
{
    public interface IUserRegistrationService
    {
        Task<UserLoginResult> ValidateUser(string userName, string password);

        Task<bool> CheckPasswordAsync(User user, string password);

        Task<User> GetUserByUserName(string userName);

        Task<UserRegistrationResult> RegisterUser(UserRegistrationRequest request);

        Task<IdentityResult> InsertUserAsync(User user, string password, IList<string> roles, IList<Claim> userClaims = null);
    }
}

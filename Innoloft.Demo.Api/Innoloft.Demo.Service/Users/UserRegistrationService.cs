using Microsoft.AspNetCore.Identity;
using Innoloft.Demo.Core.Entity.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Innoloft.Demo.Service.Users
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly UserManager<User> _userManager;
        public UserRegistrationService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public Task<bool> CheckPasswordAsync(User user, string password)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            return _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException(nameof(userName));
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(userName);
            }

            return user;
        }

        public async Task<IdentityResult> InsertUserAsync(User user, string password, IList<string> roles, IList<Claim> userClaims = null)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            IdentityResult result = await _userManager.CreateAsync(user, password);

            //result = await _userManager.AddToRolesAsync(user, roles);
            return result;
        }

        public async Task<UserRegistrationResult> RegisterUser(UserRegistrationRequest request)
        {
            if (request == null)
                throw new NotImplementedException();

            var result = new UserRegistrationResult();

            if (await GetUserByUserName(request.Email) != null)
            {
                result.AddError("Email already exist");
                return result;
            }

            User user = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDate = request.BirthDate,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                UserName = request.Email
            };
            IList<string> roles = new List<string>()
            {
                "InnoloftUser"
            };
            IdentityResult identityResult = await InsertUserAsync(user, request.Password, roles);
            if (!identityResult.Succeeded)
                result.AddError("Registration Failed");
            else
                result.User = user;

            return result;
        }

        public async Task<UserLoginResult> ValidateUser(string userName, string password)
        {
            var user = await GetUserByUserName(userName);
            if (user == null)
                return UserLoginResult.UserNotExist;
            if (!await CheckPasswordAsync(user, password))
                return UserLoginResult.WrongPassword;
            if (!user.IsActive)
                return UserLoginResult.NotActive;
            if (user.LockoutEnabled && user.LockoutEnd.HasValue && user.LockoutEnd.Value.UtcDateTime > DateTime.UtcNow)
                return UserLoginResult.LockedOut;

            return UserLoginResult.Successful;
        }
    }
}

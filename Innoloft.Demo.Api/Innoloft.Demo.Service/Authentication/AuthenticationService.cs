using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Innoloft.Demo.Core.Entity.Identity;
using Innoloft.Demo.Service.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Innoloft.Demo.Service.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        private readonly UserManager<User> _userManager;

        public AuthenticationService(UserManager<User> userManager)
        {
            _userManager = userManager;
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }
        public async Task<AuthenticationResult> AuthenticateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var tokenRequest = new TokenRequest()
            {
                Email = user.Email,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                UserId = user.Id,
            };
            TokenResult accessToken = GenerateAccessToken(tokenRequest);
            if (accessToken.Success && !await SetAccessTokenAsync(user, accessToken.Token))
                accessToken.Token = null;

            var result = new AuthenticationResult(accessToken);
            return result;
        }

        private TokenResult GenerateAccessToken(TokenRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            IList<Claim> claims = new List<Claim>()
            {
                 new Claim(UserDefaults.Claims.Name, request.UserName),
                 new Claim(UserDefaults.Claims.NameIdentifier, request.UserId.ToString(), ClaimValueTypes.Integer64),
                 new Claim(UserDefaults.Claims.Iat, DateTimeOffset.Now.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                 new Claim(UserDefaults.Claims.Email, request.Email),
                 new Claim(UserDefaults.Claims.PhoneNumber, request.PhoneNumber),
                 new Claim(UserDefaults.Claims.Id,request.UserId.ToString()),
                 new Claim(UserDefaults.Claims.Aud, UserDefaults.TokenTypes.AccessToken)
            };


            var expiry = DateTime.Now.AddDays(2);

            TokenResult response = GenerateToken(claims, expiry);
            return response;
        }

        private TokenResult GenerateToken(IList<Claim> claims, DateTime expiry)
        {
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("hpsuhdkhd6868654364545675676"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var notBefore = DateTime.Now;

            TokenResult result = new TokenResult();

            try
            {
                var securityToken = new JwtSecurityToken(
                    null,
                    null,
                    claims,
                    notBefore: notBefore,
                    expires: expiry,
                    signingCredentials: creds
                );

                string token = _jwtSecurityTokenHandler.WriteToken(securityToken);

                result.Token = token;
                result.ExpireIn = ((DateTimeOffset)expiry).ToUnixTimeSeconds();
            }
            catch
            {
                //TODO: Log
            }

            return result;
        }

        public async Task<bool> SetAccessTokenAsync(User user, string token, string tokenProvider = UserDefaults.TokenProvider)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (string.IsNullOrEmpty(tokenProvider))
                throw new ArgumentNullException(nameof(tokenProvider));
            if (string.IsNullOrEmpty(UserDefaults.TokenTypes.AccessToken))
                throw new ArgumentNullException(nameof(UserDefaults.TokenTypes.AccessToken));
            if (string.IsNullOrEmpty(token))
                throw new ArgumentNullException(nameof(token));

            IdentityResult result = await _userManager.SetAuthenticationTokenAsync(user, tokenProvider, UserDefaults.TokenTypes.AccessToken, token);

            if (!result.Succeeded)
            {
                //TODO: Log
            }

            return result.Succeeded;
        }

        public async Task<User> GetUserByClaimPrinciple(ClaimsPrincipal principal)
        {
            return await _userManager.GetUserAsync(principal);
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException(nameof(userName));

            var user = await _userManager.FindByEmailAsync(userName);

            return user;
        }
    }
}

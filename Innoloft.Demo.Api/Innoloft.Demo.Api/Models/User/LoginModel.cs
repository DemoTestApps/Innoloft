using Innoloft.Demo.Service.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Innoloft.Demo.Api.Models.User
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public LoginSuccessModel PrepareLoginSuccessModel(AuthenticationResult result)
        {
            LoginSuccessModel model = new LoginSuccessModel()
            {
                AccessToken = new LoginSuccessModel.TokenModel(result.AccessToken.Token, result.AccessToken.ExpireIn),
            };

            return model;
        }
    }

    public class LoginSuccessModel
    {
        public class TokenModel
        {
            public TokenModel(string token, long expireIn)
            {
                Token = token;
                ExpireIn = expireIn;
            }

            public string Token { get; set; }
            public long ExpireIn { get; set; }
        }

        public TokenModel AccessToken { get; set; }
    }
}

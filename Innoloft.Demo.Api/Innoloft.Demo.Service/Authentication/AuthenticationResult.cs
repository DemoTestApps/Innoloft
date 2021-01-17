using System;
using System.Collections.Generic;
using System.Text;

namespace Innoloft.Demo.Service.Authentication
{
    public class AuthenticationResult
    {
        public AuthenticationResult(TokenResult accessToken)
        {
            AccessToken = accessToken;
            Errors = new List<string>();
        }

        public TokenResult AccessToken { get; set; }
        public IList<string> Errors { get; set; }
        public bool Success => AccessToken != null && AccessToken.Success;
        public void AddError(string error)
        {
            Errors.Add(error);
        }
    }
}

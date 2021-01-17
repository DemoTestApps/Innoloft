using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Innoloft.Demo.Service.Users
{
    public static class UserDefaults
    {
        public static class Claims
        {
            public const string Id = "id";
            public const string Sub = "sub";
            public const string Iat = "iat";
            public const string Aud = "aud";
            public const string Email = ClaimTypes.Email;
            public const string PhoneNumber = "phone_number";
            public const string Name = ClaimTypes.Name;
            public const string NameIdentifier = ClaimTypes.NameIdentifier;
        }

        public static class TokenTypes
        {
            public const string AccessToken = "AccessToken";
        }

        public const string TokenProvider = "Innoloft";
    }
}

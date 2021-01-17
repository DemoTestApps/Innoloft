using System;
using System.Collections.Generic;
using System.Text;

namespace Innoloft.Demo.Service.Authentication
{
    public class TokenResult
    {
        public string Token { get; set; }
        public long ExpireIn { get; set; }
        public bool Success => !string.IsNullOrEmpty(Token);
    }
}

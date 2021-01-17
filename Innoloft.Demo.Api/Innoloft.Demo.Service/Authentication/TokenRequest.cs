using System;
using System.Collections.Generic;
using System.Text;

namespace Innoloft.Demo.Service.Authentication
{
    public class TokenRequest
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public long UserId { get; set; }
    }
}

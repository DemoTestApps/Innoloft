using System;
using System.Collections.Generic;
using System.Text;

namespace Innoloft.Demo.Service.Users
{
    public enum UserLoginResult
    {
        Successful = 1,
        UserNotExist = 2,
        WrongPassword = 3,
        NotActive = 4,
        LockedOut = 5,
    }
}

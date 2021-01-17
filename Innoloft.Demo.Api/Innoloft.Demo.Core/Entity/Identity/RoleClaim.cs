﻿using Microsoft.AspNetCore.Identity;

namespace Innoloft.Demo.Core.Entity.Identity
{
    public class RoleClaim : IdentityRoleClaim<long>
    {
        public virtual Role Role { get; set; }
    }
}
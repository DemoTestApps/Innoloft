using Microsoft.AspNetCore.Identity;
using Innoloft.Demo.Core.Entity.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Innoloft.Demo.Core.Entity.Identity
{
    public class User : IdentityUser<long>
    {
        public User()
        {
            UserTokens = new HashSet<UserToken>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DisplayName
        {
            get
            {
                var displayName = $"{FirstName} {LastName}";
                return string.IsNullOrWhiteSpace(displayName) ? UserName : displayName;
            }
        }

        public DateTime? BirthDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastVisitDate { get; set; }

        public bool IsActive { get; set; } = true;

        public virtual ICollection<UserToken> UserTokens { get; set; }

        public virtual ICollection<UserRole> Roles { get; set; }

        public virtual ICollection<UserLogin> Logins { get; set; }

        public virtual ICollection<UserClaim> Claims { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

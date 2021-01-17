using Microsoft.AspNetCore.Identity;

namespace Innoloft.Demo.Core.Entity.Identity
{
    public class UserRole : IdentityUserRole<long>
    {
        public virtual User User { get; set; }

        public virtual Role Role { get; set; }
    }
}
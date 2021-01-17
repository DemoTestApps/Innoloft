using Microsoft.AspNetCore.Identity;

namespace Innoloft.Demo.Core.Entity.Identity
{
    public class UserClaim : IdentityUserClaim<long>
    {
        public virtual User User { get; set; }
    }
}
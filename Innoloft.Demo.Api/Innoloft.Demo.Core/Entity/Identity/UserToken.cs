using Microsoft.AspNetCore.Identity;

namespace Innoloft.Demo.Core.Entity.Identity
{
    public class UserToken : IdentityUserToken<long>
    {
        public virtual User User { get; set; }
    }
}
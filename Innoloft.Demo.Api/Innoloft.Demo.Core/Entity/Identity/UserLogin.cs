using Microsoft.AspNetCore.Identity;

namespace Innoloft.Demo.Core.Entity.Identity
{
    public class UserLogin : IdentityUserLogin<long>
    {
        public virtual User User { get; set; }
    }
}
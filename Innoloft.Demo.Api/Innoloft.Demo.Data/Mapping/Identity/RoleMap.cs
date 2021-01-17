using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Innoloft.Demo.Core.Entity.Identity;

namespace Innoloft.Demo.Data.Mapping.Identity
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");

            builder.HasMany(r => r.Users)
                .WithOne(ur => ur.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            builder.HasMany(r => r.Claims)
                .WithOne(rc => rc.Role)
                .HasForeignKey(rc => rc.RoleId)
                .IsRequired();
        }
    }
}

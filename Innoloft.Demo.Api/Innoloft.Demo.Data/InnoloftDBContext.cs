using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Innoloft.Demo.Core.Entity;
using Innoloft.Demo.Core.Entity.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Innoloft.Demo.Data
{
    public class InnoloftDBContext : IdentityDbContext
        <User, Role, long, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public InnoloftDBContext(DbContextOptions<InnoloftDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var typeConfigurations = Assembly.GetExecutingAssembly().GetTypes()
               .Where(s => s.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));

            foreach (var typeConfiguration in typeConfigurations)
            {
                dynamic configuration = Activator.CreateInstance(typeConfiguration);
                modelBuilder.ApplyConfiguration(configuration);
            }

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }

        public new DbSet<T> Set<T>() where T : BaseEntity
        {
            return base.Set<T>();
        }


        public int ExecuteSqlRaw(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters)
        {
            var previousTimeout = Database.GetCommandTimeout();
            Database.SetCommandTimeout(timeout);

            var result = 0;
            if (!doNotEnsureTransaction)
            {
                using (var transaction = Database.BeginTransaction())
                {
                    result = Database.ExecuteSqlRaw(sql, parameters);
                    transaction.Commit();
                }
            }
            else
                result = Database.ExecuteSqlRaw(sql, parameters);

            Database.SetCommandTimeout(previousTimeout);

            return result;
        }
    }
}

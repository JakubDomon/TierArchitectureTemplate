using DataAccess.Configuration.Helpers;
using DataAccess.Entities.Membership;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts
{
    internal class MembershipContext(ConnectionStringHelper connectionStringHelper) : IdentityDbContext<User>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionStringHelper.MembershipConnectionString);
        }
    }
}

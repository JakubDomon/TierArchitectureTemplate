using DataAccess.Logic.Configuration.Helpers;
using DataAccess.Logic.Entities.Membership;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Logic.Contexts
{
    internal class MembershipContext(ConnectionStringHelper connectionStringHelper) : IdentityDbContext<User, Role, Guid>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionStringHelper.MembershipConnectionString);
        }
    }
}

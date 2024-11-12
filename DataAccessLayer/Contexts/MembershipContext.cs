using DataAccessLayer.Configuration.Helpers;
using DataAccessLayer.Entities.Membership;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Contexts
{
    internal class MembershipContext(ConnectionStringHelper connectionStringHelper) : IdentityDbContext<User>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionStringHelper.MembershipConnectionString);
        }
    }
}

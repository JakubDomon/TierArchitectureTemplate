using Microsoft.AspNetCore.Identity;

namespace DataAccess.Logic.Entities.Membership
{
    internal class Role : IdentityRole
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? LastEditAt { get; set; }
    }
}

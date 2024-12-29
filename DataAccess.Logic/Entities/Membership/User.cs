using Microsoft.AspNetCore.Identity;

namespace DataAccess.Logic.Entities.Membership
{
    internal class User : IdentityUser
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastEditAt { get; set; }
    }
}

﻿using Microsoft.AspNetCore.Identity;

namespace DataAccess.Logic.Entities.Membership
{
    internal class User : IdentityUser<Guid>
    {
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastEditAt { get; set; }
    }
}

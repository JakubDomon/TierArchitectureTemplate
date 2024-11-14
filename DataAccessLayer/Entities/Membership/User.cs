﻿using DataAccessLayer.Utils.UpdateHelper;
using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Entities.Membership
{
    internal class User : IdentityUser, IFluentUpdatable
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastEditAt { get; set; }
    }
}
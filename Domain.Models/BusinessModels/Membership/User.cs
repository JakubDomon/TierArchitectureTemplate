﻿namespace Domain.Models.BusinessModels.Membership
{
    public class User : ModelBase
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}

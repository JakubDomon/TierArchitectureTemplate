﻿namespace DataAccess.DTO.Membership
{
    public record UserDto : BaseDto
    {
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Guid? RoleId { get; set; }
    }
}

﻿namespace DataAccess.DTO.Membership
{
    public record UserDto : EntityDto
    {
        public string? UserName { get; init; }
        public string? Password { get; init; }
        public string? Email { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? PhoneNumber { get; init; }
    }
}

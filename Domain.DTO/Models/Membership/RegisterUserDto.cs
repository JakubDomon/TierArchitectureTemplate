﻿namespace Domain.DTO.Models.Membership
{
    public record RegisterUserDto()
    {
        public required string UserName { get; init; }
        public required string Password { get; init; }
        public required string Email { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public string? PhoneNumber { get; init; }
    }
}

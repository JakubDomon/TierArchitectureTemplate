﻿namespace Domain.DTO.Models.Membership
{
    public record RegisterUserDto()
    {
        public required string Login { get; init; }
        public required string Password { get; init; }
        public required string Email { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
    }
}

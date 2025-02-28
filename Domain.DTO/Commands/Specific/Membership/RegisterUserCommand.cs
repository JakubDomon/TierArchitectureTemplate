namespace Domain.DTO.Commands.Specific.Membership
{
    public record RegisterUserCommand(string UserName,
        string Password,
        string Email,
        string FirstName,
        string LastName,
        string? PhoneNumber) : ICommand;
}

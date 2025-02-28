namespace Domain.DTO.Commands.Specific.Membership
{
    public record AuthenticateUserCommand(string Login, string Password) : ICommand;
}

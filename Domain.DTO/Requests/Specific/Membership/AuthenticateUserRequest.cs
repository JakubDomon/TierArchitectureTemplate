namespace Domain.DTO.Requests.Specific.Membership
{
    public record AuthenticateUserRequest(string Login, string Password) : RequestBase { }
}

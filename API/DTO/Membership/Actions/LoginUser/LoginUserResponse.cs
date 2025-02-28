namespace API.DTO.Membership.Actions.LoginUser
{
    public record LoginUserResponse
    {
        public required string Token { get; init; }
    }
}

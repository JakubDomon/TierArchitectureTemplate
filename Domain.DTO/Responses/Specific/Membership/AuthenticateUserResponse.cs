using Domain.DTO.Models.Membership;

namespace Domain.DTO.Responses.Specific.Membership
{
    public record AuthenticateUserResponse(UserDto UserData, string Token) : ResponseBase { }
}

using Domain.DTO.Models.Membership;

namespace Domain.DTO.Responses.Specific.Membership
{
    public record AuthenticateUserResponse(string Token) : ResponseBase { }
}

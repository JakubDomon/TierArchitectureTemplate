using Domain.DTO.Models.Membership;

namespace Domain.DTO.Requests.Specific.Membership
{
    public record AuthenticateUserRequest(AuthenticateUserDto AuthenticationData) : RequestBase { }
}

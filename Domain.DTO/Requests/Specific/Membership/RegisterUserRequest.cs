using Domain.DTO.Models.Membership;

namespace Domain.DTO.Requests.Specific.Membership
{
    public record RegisterUserRequest(RegisterUserDto UserData) : RequestBase { }
}

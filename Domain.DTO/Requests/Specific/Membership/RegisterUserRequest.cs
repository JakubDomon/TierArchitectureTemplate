using Domain.DTO.Models.Membership;

namespace Domain.DTO.Requests.Specific.Membership
{
    public record RegisterUserRequest : RequestBase
    {
        public required UserDto UserData { get; set; }
    }
}

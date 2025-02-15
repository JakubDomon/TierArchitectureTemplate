using Domain.DTO.Models.Membership;

namespace Domain.DTO.Requests.Specific.Membership
{
    public record RegisterUserRequest : RequestBase
    {
        public required RegisterUserDto UserData { get; set; }
    }
}

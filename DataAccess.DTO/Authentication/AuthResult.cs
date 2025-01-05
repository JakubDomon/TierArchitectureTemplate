using DataAccess.DTO.Membership;

namespace DataAccess.DTO.Authentication
{
    public record AuthResult(UserDto? UserData = null);
}

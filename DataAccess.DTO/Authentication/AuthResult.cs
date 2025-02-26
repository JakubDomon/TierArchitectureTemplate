using DataAccess.DTO.Membership;

namespace DataAccess.DTO.Authentication
{
    public record AuthResult(bool IsAuthenticated, UserDto? UserData) : ActionDto;
}

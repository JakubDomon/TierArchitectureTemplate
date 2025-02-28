using API.Resources.MessagesResources.Membership;
using System.ComponentModel.DataAnnotations;

namespace API.DTO.Membership.Actions.LoginUser
{
    public record LoginUserRequest
    {
        [Required(ErrorMessageResourceName = "UserLoginRequired", ErrorMessageResourceType = typeof(MembershipValidationMessages))]
        public string? UserLogin { get; init; }

        [Required(ErrorMessageResourceName = "UserPasswordRequired", ErrorMessageResourceType = typeof(MembershipValidationMessages))]
        public string? Password { get; init; }
    }
}

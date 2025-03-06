using API.Resources.MessagesResources.Membership;
using System.ComponentModel.DataAnnotations;

namespace API.DTO.Membership.Actions.LoginUser
{
    public record LoginUserRequest
    {
        [Required(ErrorMessageResourceName = "UserLoginRequired", ErrorMessageResourceType = typeof(MembershipValidationMessages))]
        public required string UserLogin { get; init; }

        [Required(ErrorMessageResourceName = "UserPasswordRequired", ErrorMessageResourceType = typeof(MembershipValidationMessages))]
        public required string Password { get; init; }
    }
}

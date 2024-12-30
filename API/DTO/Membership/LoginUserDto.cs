using API.DTO.MessagesResources;
using System.ComponentModel.DataAnnotations;

namespace API.DTO.Membership
{
    public class LoginUserDto
    {
        [Required(ErrorMessageResourceName = "UserLoginRequired", ErrorMessageResourceType = typeof(MembershipValidationMessages))]
        public string? UserLogin { get; set; }

        [Required(ErrorMessageResourceName = "UserPasswordRequired", ErrorMessageResourceType = typeof(MembershipValidationMessages))]
        public string? Password { get; set; }
    }
}

using API.DTO.MessagesResources;
using System.ComponentModel.DataAnnotations;

namespace API.DTO.Membership
{
    public class RegisterUserDto
    {
        [Required(ErrorMessageResourceName = "UserLoginRequired", ErrorMessageResourceType = typeof(MembershipValidationMessages))]
        [MinLength(5, ErrorMessageResourceName = "UserLoginTooShort", ErrorMessageResourceType = typeof(MembershipValidationMessages))]
        public string? Login { get; set; }

        [Required(ErrorMessageResourceName = "UserPasswordRequired", ErrorMessageResourceType = typeof(MembershipValidationMessages))]
        [MinLength(8, ErrorMessageResourceName = "UserPasswordTooShort", ErrorMessageResourceType = typeof(MembershipValidationMessages))]
        [RegularExpression(@"^(?=.*\\d.*\\d)(?=.*[!@#$%^&*(),.?\"":{}|<>]).*$", ErrorMessageResourceName = "UserPasswordConditionsNotMet", ErrorMessageResourceType = typeof(MembershipValidationMessages))]
        public string? Password { get; set; }

        [Required(ErrorMessageResourceName = "UserEmailRequired", ErrorMessageResourceType = typeof(MembershipValidationMessages))]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessageResourceName = "UserEmailConditionsNotMet", ErrorMessageResourceType = typeof(MembershipValidationMessages))]
        public string? Email { get; set; }

        [Required(ErrorMessageResourceName = "UserFirstNameRequired", ErrorMessageResourceType = typeof(MembershipValidationMessages))]
        [MinLength(2, ErrorMessageResourceName = "UserFirstNameTooShort", ErrorMessageResourceType = typeof(MembershipValidationMessages))]
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
    }
}

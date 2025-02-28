using API.Resources.MessagesResources.Membership;
using System.ComponentModel.DataAnnotations;

namespace API.DTO.Membership.Actions.RegisterUser
{
    public record RegisterUserRequest
    {
        [Required(ErrorMessageResourceName = "UserLoginRequired", ErrorMessageResourceType = typeof(MembershipValidationMessages))]
        [MinLength(4, ErrorMessageResourceName = "UserLoginTooShort", ErrorMessageResourceType = typeof(MembershipValidationMessages))]
        public string? UserName { get; init; }

        [Required(ErrorMessageResourceName = "UserPasswordRequired", ErrorMessageResourceType = typeof(MembershipValidationMessages))]
        [MinLength(8, ErrorMessageResourceName = "UserPasswordTooShort", ErrorMessageResourceType = typeof(MembershipValidationMessages))]
        [RegularExpression(@"^(?=.*\\d.*\\d)(?=.*[!@#$%^&*(),.?\"":{}|<>]).*$", ErrorMessageResourceName = "UserPasswordConditionsNotMet", ErrorMessageResourceType = typeof(MembershipValidationMessages))]
        public string? Password { get; init; }

        [Required(ErrorMessageResourceName = "UserEmailRequired", ErrorMessageResourceType = typeof(MembershipValidationMessages))]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessageResourceName = "UserEmailConditionsNotMet", ErrorMessageResourceType = typeof(MembershipValidationMessages))]
        public string? Email { get; init; }

        [Required(ErrorMessageResourceName = "UserFirstNameRequired", ErrorMessageResourceType = typeof(MembershipValidationMessages))]
        [MinLength(2, ErrorMessageResourceName = "UserFirstNameTooShort", ErrorMessageResourceType = typeof(MembershipValidationMessages))]
        public string? FirstName { get; init; }

        public string? LastName { get; init; }
    }
}

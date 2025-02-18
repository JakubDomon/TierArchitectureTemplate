using Domain.DTO.Models.Membership;
using Domain.Logic.Common.Validators.Rules;
using Domain.Logic.Resources.Messages.Helpers;
using Domain.Logic.Resources.Messages.Membership;
using FluentValidation;

namespace Domain.Logic.Modules.Validators.Membership.Rules.DataRules
{
    internal class RegisterUserDataRule(RegisterUserDto userDto) : ValidationRuleBase<RegisterUserDto>(userDto)
    {
        protected override void PrepareSubRules()
        {
            RuleFor(x => x.Login).NotEmpty().WithMessage(MembershipValidationMessages.UserLoginRequired)
                .MinimumLength(3).WithMessage("");
            RuleFor(x => x.Password).NotEmpty().WithMessage(MembershipValidationMessages.UserPasswordRequired);
            RuleFor(x => x.Email).NotEmpty().WithMessage(MembershipValidationMessages.UserEmailRequired);
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(MembershipValidationMessages.UserFirstNameRequired);
            RuleFor(x => x.LastName).NotEmpty().WithMessage(MembershipValidationMessages.UserLastNameRequired);
        }
    }
}

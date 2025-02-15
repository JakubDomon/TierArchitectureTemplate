using Domain.DTO.Models.Membership;
using Domain.Logic.Common.Validators.Rules;
using Domain.Logic.Resources.Messages;
using FluentValidation;

namespace Domain.Logic.Modules.Validators.Membership.Rules.DataRules
{
    internal class RegisterUserDataRule(RegisterUserDto userDto) : ValidationRuleBase<RegisterUserDto>(userDto)
    {
        protected override void PrepareSubRules()
        {
            RuleFor(x => x.Login).NotEmpty().WithMessage(UserValidationMessages.UserLoginRequired);
            RuleFor(x => x.Password).NotEmpty().WithMessage(UserValidationMessages.UserPasswordRequired);
            RuleFor(x => x.Email).NotEmpty().WithMessage(UserValidationMessages.UserEmailRequired);
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(UserValidationMessages.UserFirstNameRequired);
            RuleFor(x => x.LastName).NotEmpty().WithMessage(UserValidationMessages.UserLastNameRequired);
        }
    }
}

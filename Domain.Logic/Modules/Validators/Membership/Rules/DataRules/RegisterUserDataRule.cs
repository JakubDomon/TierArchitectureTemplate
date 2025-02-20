using Domain.DTO.Models.Membership;
using Domain.Logic.Common.Validators.Rules;
using Domain.Logic.Resources.Messages.Common;
using Domain.Logic.Resources.Messages.Common.Properties;
using Domain.Logic.Resources.Messages.Helpers;
using Domain.Logic.Resources.Messages.Membership;
using FluentValidation;

namespace Domain.Logic.Modules.Validators.Membership.Rules.DataRules
{
    internal class RegisterUserDataRule(RegisterUserDto userDto) : ValidationRuleBase<RegisterUserDto>(userDto)
    {
        protected override void PrepareSubRules()
        {
            RuleFor(x => x.Login)
                .NotEmpty().WithMessage(CommonValidationMessages.PropertyRequired.FillMessage(PropertyNames.Login))
                .MinimumLength(3).WithMessage(CommonValidationMessages.PropertyValueTooShort.FillMessage(PropertyNames.Login, 3))
                .MaximumLength(10).WithMessage(CommonValidationMessages.PropertyValueTooLong.FillMessage(PropertyNames.Login, 10));

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(MembershipValidationMessages.UserPasswordRequired);

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(MembershipValidationMessages.UserEmailRequired);

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage(MembershipValidationMessages.UserFirstNameRequired);

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage(MembershipValidationMessages.UserLastNameRequired);
        }
    }
}

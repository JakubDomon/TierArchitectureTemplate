using Domain.DTO.Commands.Specific.Membership;
using Domain.Logic.Common.Validators.Rules;
using Domain.Logic.Resources.Messages.Common;
using Domain.Logic.Resources.Messages.Common.Properties;
using Domain.Logic.Resources.Messages.Helpers;
using FluentValidation;

namespace Domain.Logic.Modules.Validators.Membership.Rules.DataRules
{
    internal class RegisterUserDataRule(RegisterUserCommand userDto) : ValidationRuleBase<RegisterUserCommand>(userDto)
    {
        protected override void PrepareSubRules()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage(CommonValidationMessages.PropertyRequired.FillMessage(PropertyNames.Login))
                .MinimumLength(3).WithMessage(CommonValidationMessages.PropertyValueTooShort.FillMessage(PropertyNames.Login, 3))
                .MaximumLength(10).WithMessage(CommonValidationMessages.PropertyValueTooLong.FillMessage(PropertyNames.Login, 10));

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(CommonValidationMessages.PropertyRequired.FillMessage(PropertyNames.Password))
                .MinimumLength(8).WithMessage(CommonValidationMessages.PropertyValueTooShort.FillMessage(PropertyNames.Password, 8));

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(CommonValidationMessages.PropertyRequired.FillMessage(PropertyNames.Email))
                .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$").WithMessage(CommonValidationMessages.PropertyValueInvalid.FillMessage(PropertyNames.Email));

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage(CommonValidationMessages.PropertyRequired.FillMessage(PropertyNames.FirstName))
                .Matches(@"^[a-zA-Z]+$").WithMessage(CommonValidationMessages.PropertyValueInvalid.FillMessage(PropertyNames.FirstName));

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage(CommonValidationMessages.PropertyRequired.FillMessage(PropertyNames.LastName))
                .Matches(@"^[a-zA-Z]+$").WithMessage(CommonValidationMessages.PropertyValueInvalid.FillMessage(PropertyNames.LastName));
        }
    }
}

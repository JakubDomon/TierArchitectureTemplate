using Domain.DTO.Messages;
using Domain.Logic.Common.Validators;
using Domain.Models.Validation.Enums;

namespace Domain.Logic.Modules.Validators.Membership.Rules
{
    internal class ValidateUserPasswordRule : ValidationRuleBase(ValidationScope.UserValidation)
    {
        public override Task<IMessage?> ValidateAsync()
        {
            throw new NotImplementedException();
        }
    }
}

using Domain.DTO.Messages;
using Domain.Logic.Common.Validators;
using Domain.Logic.Resources.Messages;
using Domain.Models.Validation.Enums;
using System.Drawing.Text;

namespace Domain.Logic.Modules.Validators.Membership.Rules
{
    internal class ValidateUserLoginRule(string userLogin) : ValidationRuleBase(ValidationScope.UserValidation)
    {
        private readonly string _userLogin = userLogin;

        public override async Task<IMessage?> ValidateAsync()
        {
            return string.IsNullOrWhiteSpace(_userLogin)
                ? CreateError(UserValidationMessages.UserLoginInvalid)
                : null;
        }
    }
}

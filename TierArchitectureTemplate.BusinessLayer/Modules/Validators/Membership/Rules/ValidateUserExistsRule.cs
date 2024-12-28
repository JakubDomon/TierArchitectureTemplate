using BusinessLayer.Logic.Common.Validators;
using BusinessLayer.Logic.Resources.Messages;
using BusinessLayer.Models.Communication.Messages.Messages;
using BusinessLayer.Models.Communication.Validation.Enums;
using DataAccessLayer.Repositories.Membership;

namespace BusinessLayer.Logic.Modules.Validators.Membership.Rules
{
    internal class ValidateUserExistsRule(string userLogin, IUserRepository userRepository) : ValidationRuleBase(ValidationScope.UserValidation)
    {
        private string _userLogin { get; } = userLogin;
        private IUserRepository _userRepository { get; } = userRepository;

        public override async Task<IMessage?> ValidateAsync()
        {
            if (await _userRepository.UserExists(_userLogin))
                return CreateError(UserValidationMessages.UserAlreadyExists);

            return null;
        }
    }
}

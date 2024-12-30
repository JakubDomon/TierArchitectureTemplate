using DataAccess.Logic.Repositories.Membership;
using Domain.DTO.Messages;
using Domain.Logic.Common.Validators;
using Domain.Logic.Resources.Messages;
using Domain.Models.Validation.Enums;

namespace Domain.Logic.Modules.Validators.Membership.Rules
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

using DataAccess.Logic.Repositories.Membership;
using Domain.DTO.Requests.Specific.Membership;
using Domain.Logic.Common.Validators;
using Domain.Logic.Modules.Validators.Membership.Rules;

namespace Domain.Logic.Modules.Validators.Membership
{
    internal class RegisterUserValidator(IUserRepository userRepository) : ValidatorBase<RegisterUserRequest>
    {
        private IUserRepository _userRepository { get; } = userRepository;

        protected override void PrepareValidationRules(RegisterUserRequest input)
        {
            AddValidationRule(new ValidateUserExistsRule(input.UserData.Username, _userRepository));
        }
    }
}

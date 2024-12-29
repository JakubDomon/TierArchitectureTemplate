using BusinessLayer.Logic.Modules.Validators.Membership.Rules;
using DataAccess.Repositories.Membership;
using Domain.DTO.Requests.Specific.Membership;
using Domain.Logic.Common.Validators;

namespace Domain.Logic.Modules.Validators.Membership
{
    internal class RegisterUserValidator(IUserRepository userRepository) : ValidatorBase<RegisterUserRequest>
    {
        private IUserRepository _userRepository { get; } = userRepository;

        protected override void PrepareValidationRules(RegisterUserRequest input)
        {
            AddValidationRule(new ValidateUserExistsRule(input.UserName, _userRepository));
        }
    }
}

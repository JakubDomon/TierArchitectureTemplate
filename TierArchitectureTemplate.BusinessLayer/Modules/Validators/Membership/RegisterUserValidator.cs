using BusinessLayer.Logic.Common.Validators;
using BusinessLayer.Logic.Modules.Validators.Membership.Rules;
using BusinessLayer.Models.Communication.Messages.Requests.Specific.Membership;
using DataAccessLayer.Repositories.Membership;

namespace BusinessLayer.Logic.Modules.Validators.Membership
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

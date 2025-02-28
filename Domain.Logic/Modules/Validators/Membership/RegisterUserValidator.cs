using DataAccess.Logic.Repositories.Membership;
using Domain.DTO.Commands.Specific.Membership;
using Domain.Logic.Common.Validators;
using Domain.Logic.Modules.Validators.Membership.Rules;
using Domain.Logic.Modules.Validators.Membership.Rules.DataRules;

namespace Domain.Logic.Modules.Validators.Membership
{
    internal class RegisterUserValidator(IUserRepository userRepository) : ValidatorBase<RegisterUserCommand>
    {
        private IUserRepository _userRepository { get; } = userRepository;

        protected override void PrepareValidationRules(RegisterUserCommand input)
        {
            AddValidationRule(new RegisterUserDataRule(input));
            AddValidationRule(new ValidateUserExistsRule(input.UserName, _userRepository));
        }
    }
}

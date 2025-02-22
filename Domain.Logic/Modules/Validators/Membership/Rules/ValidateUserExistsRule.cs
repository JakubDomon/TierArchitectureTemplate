using DataAccess.Logic.Repositories.Membership;
using Domain.Logic.Common.Validators.Rules;
using Domain.Logic.Resources.Messages.Membership;
using FluentValidation;

namespace Domain.Logic.Modules.Validators.Membership.Rules
{
    internal class ValidateUserExistsRule(string userLogin, IUserRepository userRepository) : ValidationRuleBase<string>(userLogin)
    {
        private IUserRepository _userRepository { get; } = userRepository;

        protected override void PrepareSubRules()
        {
            RuleFor(x => x).MustAsync((x, cancellation) => UserExists(x, cancellation)).WithMessage(MembershipValidationMessages.UserAlreadyExists);
        }

        private async Task<bool> UserExists(string userLogin, CancellationToken cancellation) => await _userRepository.UserExists(userLogin);
    }
}

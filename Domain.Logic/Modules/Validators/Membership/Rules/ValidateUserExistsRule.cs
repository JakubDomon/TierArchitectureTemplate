using AutoMapper;
using DataAccess.Logic.Repositories.Membership;
using Domain.Logic.Common.Validators.Rules;
using Domain.Logic.Resources.Messages;
using FluentValidation;

namespace Domain.Logic.Modules.Validators.Membership.Rules
{
    internal class ValidateUserExistsRule(string userLogin, IUserRepository userRepository) : ValidationRuleBase<string>(userLogin)
    {
        private IUserRepository _userRepository { get; } = userRepository;

        protected override void PrepareSubRules()
        {
            RuleFor(x => x).MustAsync((x, cancellation) => UserExists(x)).WithMessage(UserValidationMessages.UserAlreadyExists);
        }

        private async Task<bool> UserExists(string userLogin) => await _userRepository.UserExists(userLogin);
    }
}

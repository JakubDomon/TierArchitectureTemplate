using DataAccess.Logic.Repositories.Membership;
using Domain.DTO.Messages;
using Domain.Logic.Common.Validators;
using Domain.Logic.Common.Validators.Rules;
using Domain.Logic.Resources.Messages;
using Domain.Models.Validation.Enums;

namespace Domain.Logic.Modules.Validators.Membership.Rules
{
    internal class ValidateUserExistsRule(string userLogin, IUserRepository userRepository) : ValidationRuleBase<string>
    {
        private IUserRepository _userRepository { get; } = userRepository;

        protected override void PrepareSubRules()
        {
            throw new NotImplementedException();
        }
    }
}

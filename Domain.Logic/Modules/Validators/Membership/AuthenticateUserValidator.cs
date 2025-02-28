using Domain.DTO.Commands.Specific.Membership;
using Domain.Logic.Common.Validators;

namespace Domain.Logic.Modules.Validators.Membership
{
    internal class AuthenticateUserValidator() : ValidatorBase<AuthenticateUserCommand>
    {
        protected override void PrepareValidationRules(AuthenticateUserCommand input)
        {
            
        }
    }
}

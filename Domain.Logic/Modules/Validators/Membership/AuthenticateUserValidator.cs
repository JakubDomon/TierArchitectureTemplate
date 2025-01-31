using Domain.DTO.Requests.Specific.Membership;
using Domain.Logic.Common.Validators;

namespace Domain.Logic.Modules.Validators.Membership
{
    internal class AuthenticateUserValidator() : ValidatorBase<AuthenticateUserRequest>
    {
        protected override void PrepareValidationRules(AuthenticateUserRequest input)
        {
            
        }
    }
}

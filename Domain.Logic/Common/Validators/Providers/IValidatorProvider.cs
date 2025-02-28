using Domain.DTO.Common;

namespace Domain.Logic.Common.Validators.Providers
{
    internal interface IValidatorProvider
    {
        public IValidator<Action> GetValidator<Action>()
            where Action : IAction;
    }
}

using Domain.DTO.Common;
using Domain.Models.Validation.Specific;

namespace Domain.Logic.Common.Validators
{
    internal interface IValidator<Action>
        where Action : IAction
    {
        public Task<ValidationResult> ValidateAsync(Action input);
    }
}

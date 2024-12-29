using Domain.DTO.Requests;
using Domain.Models.Validation.Specific;

namespace Domain.Logic.Common.Validators
{
    internal interface IValidator<Input>
        where Input : RequestBase
    {
        public Task<ValidationResult> ValidateAsync(Input input);
    }
}

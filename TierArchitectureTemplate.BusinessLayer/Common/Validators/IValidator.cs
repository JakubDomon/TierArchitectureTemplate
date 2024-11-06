using BusinessLayer.Logic.Common.Communication;
using BusinessLayer.Models.Communication.Concrete.Validation;

namespace BusinessLayer.Logic.Common.Validators
{
    internal interface IValidator<Input>
        where Input : RequestBase
    {
        public Task<ValidationResult> ValidateAsync(Input input);
    }
}

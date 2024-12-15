using BusinessLayer.Models.Communication.Messages.Requests;
using BusinessLayer.Models.Communication.Validation.Specific;

namespace BusinessLayer.Logic.Common.Validators
{
    internal interface IValidator<Input>
        where Input : RequestBase
    {
        public Task<ValidationResult> ValidateAsync(Input input);
    }
}

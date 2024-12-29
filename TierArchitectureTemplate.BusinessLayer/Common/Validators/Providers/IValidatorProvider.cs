using Domain.DTO.Requests;

namespace Domain.Logic.Common.Validators.Providers
{
    internal interface IValidatorProvider
    {
        public IValidator<Input> GetValidator<Input>()
            where Input : RequestBase;
    }
}

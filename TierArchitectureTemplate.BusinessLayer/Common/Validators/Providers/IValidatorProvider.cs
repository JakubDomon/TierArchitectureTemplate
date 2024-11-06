using BusinessLayer.Logic.Common.Communication;

namespace BusinessLayer.Logic.Common.Validators.Providers
{
    internal interface IValidatorProvider
    {
        public IValidator<Input> GetValidator<Input>()
            where Input : RequestBase; 
    }
}

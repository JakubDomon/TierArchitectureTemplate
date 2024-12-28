using BusinessLayer.Models.Communication.Messages.Requests;
using System.Reflection;

namespace BusinessLayer.Logic.Common.Validators.Providers
{
    internal class ValidatorProvider : IValidatorProvider
    {
        private readonly IServiceProvider _serviceProvider;

        internal ValidatorProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IValidator<Input> GetValidator<Input>() where Input : RequestBase
        {
            var validator = _serviceProvider.GetService(typeof(IValidator<Input>));

            if(validator == null)
                throw new InvalidOperationException($"No validator found for input type {typeof(Input).Name}");

            return (IValidator<Input>)validator;
        }
    }
}

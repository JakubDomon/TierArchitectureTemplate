using Domain.DTO.Common;

namespace Domain.Logic.Common.Validators.Providers
{
    internal class ValidatorProvider : IValidatorProvider
    {
        private readonly IServiceProvider _serviceProvider;

        internal ValidatorProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IValidator<Action> GetValidator<Action>() where Action : IAction
        {
            var validator = _serviceProvider.GetService(typeof(IValidator<Action>));

            if (validator is null)
                throw new InvalidOperationException($"No validator found for input type {typeof(Action).Name}");

            return (IValidator<Action>)validator;
        }
    }
}

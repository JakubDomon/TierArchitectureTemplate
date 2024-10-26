using BusinessLayer.Communication;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace BusinessLayer.Logic.Common.Validators.Providers
{
    internal class ValidatorProvider : IValidatorProvider
    {
        private Dictionary<Type, Type> validators = [];

        public ValidatorProvider(Assembly assembly)
        {
            LoadValidatorsFromAssembly(assembly);
        }

        private void LoadValidatorsFromAssembly(Assembly assembly)
        {
            var validatorTypes = assembly.GetTypes()
                .Where(type => type.GetInterfaces()
                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IValidator<>)))
                .ToList();

            foreach(var validatorType in validatorTypes)
            {
                var interfaceType = validatorType.GetInterfaces()
                    .First(i => i.GetGenericTypeDefinition() == typeof(IValidator<>));

                validators[interfaceType.GenericTypeArguments.First()] = validatorType;
            }
        }

        public IValidator<Input> GetValidator<Input>() where Input : RequestBase
        {
            if(validators.TryGetValue(typeof(Input), out var validatorType))
            {
                var instance = Activator.CreateInstance(validatorType);

                if(instance != null)
                {
                    return (IValidator<Input>)instance;
                }
                else
                {
                    throw new InvalidOperationException($"No validator found for input type {typeof(Input).Name}");
                }
            }

            throw new InvalidOperationException($"No validator found for input type {typeof(Input).Name}");
        }
    }
}

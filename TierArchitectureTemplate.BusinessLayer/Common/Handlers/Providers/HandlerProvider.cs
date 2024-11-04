using BusinessLayer.Communication;
using System.Reflection;

namespace BusinessLayer.Logic.Common.Handlers.Providers
{
    internal class HandlerProvider : IHandlerProvider
    {
        private readonly Dictionary<(Type, Type), Type> handlers = [];

        public HandlerProvider(Assembly assembly)
        {
            LoadHandlersFromAssembly(assembly);
        }

        public IHandler<Input, Output> GetHandler<Input, Output>()
            where Input : RequestBase
            where Output : ResponseBase
        {
            if(handlers.TryGetValue((typeof(Input), typeof(Output)), out var handlerType))
            {
                var instance = Activator.CreateInstance(handlerType);

                if(instance != null)
                {
                    return (IHandler<Input, Output>)instance;
                }
                else
                {
                    throw new InvalidOperationException($"No handler found for types {typeof(Input).Name}, {typeof(Output).Name}");
                }
            }

            throw new InvalidOperationException($"No handler found for types {typeof(Input).Name}, {typeof(Output).Name}");
        }

        private void LoadHandlersFromAssembly(Assembly assembly)
        {
            var handlerTypes = assembly.GetTypes()
                .Where(type => type.GetInterfaces()
                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IHandler<,>)))
                .ToList();

            foreach (var handlerType in handlerTypes)
            {
                var interfaceType = handlerType.GetInterfaces()
                    .First(i => i.GetGenericTypeDefinition() == typeof(IHandler<,>));

                handlers[(interfaceType.GenericTypeArguments.First(), interfaceType.GenericTypeArguments.Last())] = handlerType;
            }
    }
}

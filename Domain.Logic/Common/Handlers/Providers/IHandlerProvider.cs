using Domain.DTO.Common;

namespace Domain.Logic.Common.Handlers.Providers
{
    internal interface IHandlerProvider
    {
        public IHandler<Input, Output> GetHandler<Input, Output>()
            where Input : IAction;
    }
}

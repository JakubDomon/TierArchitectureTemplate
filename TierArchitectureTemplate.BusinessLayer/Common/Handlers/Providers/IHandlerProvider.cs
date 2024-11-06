using BusinessLayer.Logic.Common.Communication;

namespace BusinessLayer.Logic.Common.Handlers.Providers
{
    internal interface IHandlerProvider
    {
        public IHandler<Input, Output> GetHandler<Input, Output>()
            where Input : RequestBase
            where Output : ResponseBase;
    }
}

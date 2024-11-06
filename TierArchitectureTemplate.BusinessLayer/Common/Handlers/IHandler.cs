using BusinessLayer.Logic.Common.Communication;

namespace BusinessLayer.Logic.Common.Handlers
{
    internal interface IHandler<Input, Output>
        where Input : RequestBase
        where Output : ResponseBase
    {
        public Task<Output> HandleAsync(Input request);
    }
}

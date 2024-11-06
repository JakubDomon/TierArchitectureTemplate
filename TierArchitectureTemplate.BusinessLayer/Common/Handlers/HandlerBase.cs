using BusinessLayer.Logic.Common.Communication;
namespace BusinessLayer.Logic.Common.Handlers
{
    internal abstract class HandlerBase<Input, Output> : IHandler<Input, Output>
        where Input : RequestBase
        where Output : ResponseBase, new()
    {
        public HandlerBase() { }

        public async Task<Output> HandleAsync(Input request)
        {
            return await HandleInternalAsync(request);
        }

        protected abstract Task<Output> HandleInternalAsync(Input request);
    }
}

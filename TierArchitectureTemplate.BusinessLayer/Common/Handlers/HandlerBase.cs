using BusinessLayer.Models.Communication.Messages.Requests;
using BusinessLayer.Models.Communication.Messages.Responses;
namespace BusinessLayer.Logic.Common.Handlers
{
    internal abstract class HandlerBase<Input, Output> : IHandler<Input, Output>
        where Input : RequestBase
        where Output : ResponseBase, new()
    {
        internal HandlerBase() { }
        public async Task<Output?> HandleAsync(Input request)
        {
            try
            {
                return await HandleInternalAsync(request);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return null;
            }
        }

        protected abstract Task<Output> HandleInternalAsync(Input request);

        private void HandleException(Exception ex)
        {

        }
    }
}

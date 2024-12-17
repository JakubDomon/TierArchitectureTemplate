using BusinessLayer.Models.Communication.Handlers.Specific;
using BusinessLayer.Models.Communication.Messages.Requests;
using BusinessLayer.Models.Communication.Messages.Responses;

namespace BusinessLayer.Logic.Common.Handlers
{
    internal interface IHandler<Input, Output>
        where Input : RequestBase
        where Output : ResponseBase
    {
        public Task<HandlerResult<Output>> HandleAsync(Input request);
    }
}

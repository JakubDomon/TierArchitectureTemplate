using BusinessLayer.Models.Communication.Messages.Requests;
using BusinessLayer.Models.Communication.Messages.Responses;

namespace BusinessLayer.Logic.Common.Handlers.Providers
{
    internal interface IHandlerProvider
    {
        public IHandler<Input, Output> GetHandler<Input, Output>()
            where Input : RequestBase
            where Output : ResponseBase;
    }
}

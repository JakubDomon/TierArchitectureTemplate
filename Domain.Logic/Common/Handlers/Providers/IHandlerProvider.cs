using Domain.DTO.Requests;
using Domain.DTO.Responses;

namespace Domain.Logic.Common.Handlers.Providers
{
    internal interface IHandlerProvider
    {
        public IHandler<Input, Output> GetHandler<Input, Output>()
            where Input : RequestBase
            where Output : ResponseBase;
    }
}

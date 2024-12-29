using BusinessLayer.Models.Communication.Handlers.Specific;
using Domain.DTO.Requests;
using Domain.DTO.Responses;
using Domain.Logic.Common.Handlers;

namespace Domain.Logic.Common.Handlers.Providers
{
    internal interface IHandlerProvider
    {
        public IHandler<Input, Output> GetHandler<Input, Output>()
            where Input : RequestBase
            where Output : ResponseBase;
    }
}

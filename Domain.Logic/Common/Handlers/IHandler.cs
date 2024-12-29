using Domain.DTO.Requests;
using Domain.DTO.Responses;
using Domain.Models.Handlers.Specific;

namespace Domain.Logic.Common.Handlers
{
    internal interface IHandler<Input, Output>
        where Input : RequestBase
        where Output : ResponseBase
    {
        public Task<HandlerResult<Output>> HandleAsync(Input request);
    }
}

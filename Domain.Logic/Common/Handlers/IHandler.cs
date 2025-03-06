using Domain.DTO.Common;
using Domain.Models.Handlers.Specific;

namespace Domain.Logic.Common.Handlers
{
    internal interface IHandler<Input, Output>
        where Input : IAction
    {
        public Task<HandlerResult<Output>> HandleAsync(Input request, CancellationToken ct);
    }
}

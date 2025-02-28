using Domain.DTO.Messages;
using Domain.Models.Handlers.Specific;

namespace Domain.Logic.Modules.Handlers.Helpers
{
    internal static class HandlerResultHelper
    {
        public static HandlerResult<Data> CreateHandlerResult<Data>(Data? data = default, IEnumerable<IMessage>? messages = null)
            where Data : class => new()
            {
                Data = data,
                Messages = messages ?? Enumerable.Empty<IMessage>()
            };
    }
}

using BusinessLayer.Models.Communication.Handlers.Specific;
using BusinessLayer.Models.Communication.Messages.Messages;
using BusinessLayer.Models.Communication.Messages.Responses;

namespace BusinessLayer.Logic.Modules.Handlers.Helpers
{
    internal static class HandlerResultHelper
    {
        public static HandlerResult<Data> CreateHandlerResult<Data>(Data data, IEnumerable<IMessage>? messages = null)
            where Data : ResponseBase => new()
            {
                Data = data,
                Messages = messages ?? Enumerable.Empty<IMessage>()
            };
    }
}

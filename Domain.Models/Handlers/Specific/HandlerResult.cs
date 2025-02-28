using Domain.DTO.Messages;
using Domain.DTO.Messages.Enums;

namespace Domain.Models.Handlers.Specific
{
    public record HandlerResult<Output>
        where Output : class
    {
        public IEnumerable<IMessage> Messages { get; init; } = [];
        public bool IsSuccess => !Messages.Any(x => x.Type == MessageType.Error) && Data != null;
        public Output? Data { get; init; }
    }
}

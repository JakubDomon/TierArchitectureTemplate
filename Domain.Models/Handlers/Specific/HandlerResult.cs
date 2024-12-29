using Domain.DTO.Messages;
using Domain.DTO.Messages.Enums;
using Domain.DTO.Responses;

namespace Domain.Models.Handlers.Specific
{
    public record HandlerResult<Output>
        where Output : ResponseBase
    {
        public IEnumerable<IMessage> Messages { get; set; } = [];
        public bool IsSucceeded => !Messages.Any(x => x.Type == MessageType.Error) && Data != null;
        public Output? Data { get; set; }
    }
}

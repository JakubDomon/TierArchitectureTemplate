using BusinessLayer.Models.Communication.Messages.Messages;
using BusinessLayer.Models.Communication.Messages.Messages.Enums;
using BusinessLayer.Models.Communication.Messages.Responses;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BusinessLayer.Models.Communication.Handlers.Specific
{
    public record HandlerResult<Output>
        where Output : ResponseBase
    {
        public IEnumerable<IMessage> Messages { get; set; } = [];
        public bool IsSucceeded => !Messages.Any(x => x.Type == MessageType.Error) && Data != null;
        public Output? Data { get; set; }
    }
}

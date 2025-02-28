using Domain.DTO.Messages;
using Domain.DTO.Messages.Enums;

namespace Domain.DTO.Common
{
    public record UnifiedResponse<Payload>
    {
        public Payload? Data { get; set; }
        public IEnumerable<IMessage> Messages { get; set; } = [];
        public bool IsSuccess
        {
            get => !Messages.Any(x => x.Type == MessageType.Error)
                && Data != null;
        }
    }
}

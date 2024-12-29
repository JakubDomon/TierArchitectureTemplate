using Domain.DTO.Messages.Enums;

namespace Domain.DTO.Messages
{
    public interface IMessage
    {
        public string Code { get; }
        public string Message { get; }
        public MessageType Type { get; }
    }
}

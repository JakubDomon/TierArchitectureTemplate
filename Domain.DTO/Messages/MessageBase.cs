using Domain.DTO.Messages.Enums;

namespace Domain.DTO.Messages
{
    public abstract record MessageBase(string Code, string Message) : IMessage
    {
        public abstract MessageType Type { get; }
    }
}

using BusinessLayer.Models.Communication.Messages.Messages.Enums;

namespace BusinessLayer.Models.Communication.Messages.Messages
{
    public abstract record MessageBase(string Code, string Message) : IMessage
    {
        public abstract MessageType Type { get; }
    }
}

using BusinessLayer.Models.Communication.Messages.Messages.Enums;

namespace BusinessLayer.Models.Communication.Messages.Messages
{
    public abstract class MessageBase(string code, string message) : IMessage
    {
        public string Code { get => code; }
        public string Message { get => message; }
        public abstract MessageType Type { get; }
    }
}

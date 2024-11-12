using BusinessLayer.Models.Communication.Enums;

namespace BusinessLayer.Models.Communication
{
    public abstract class MessageBase(string code, string message) : IMessage
    {
        public string Code { get => code; }
        public string Message { get => message; }
        public abstract MessageType Type { get; }
    }
}

using BusinessLayer.Models.Communication.Messages.Messages.Enums;

namespace BusinessLayer.Models.Communication.Messages.Messages
{
    public interface IMessage
    {
        public string Code { get; }
        public string Message { get; }
        public MessageType Type { get; }
    }
}

using BusinessLayer.Models.Communication.Enums;

namespace BusinessLayer.Models.Communication
{
    public interface IMessage
    {
        public string Code { get; }
        public string Message { get; }
        public MessageType Type { get; }
    }
}

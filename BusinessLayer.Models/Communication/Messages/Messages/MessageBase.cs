using BusinessLayer.Models.Communication.Messages.Messages.Enums;

namespace BusinessLayer.Models.Communication.Messages.Messages
{
    public abstract record MessageBase : IMessage
    {
        public required string Code { get; set; }
        public required string Message { get; set; }
        public abstract MessageType Type { get; }
    }
}

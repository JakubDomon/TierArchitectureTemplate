using BusinessLayer.Models.Communication.Messages.Messages.Enums;

namespace BusinessLayer.Models.Communication.Messages.Messages.Specific
{
    public record ErrorMessage(string Code, string Message) : MessageBase(Code, Message)
    {
        public override MessageType Type => MessageType.Error;
    }
}

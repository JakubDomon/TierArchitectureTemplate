using BusinessLayer.Models.Communication.Messages.Messages.Enums;

namespace BusinessLayer.Models.Communication.Messages.Messages.Specific
{
    public record ErrorMessage : MessageBase
    {
        public override MessageType Type => MessageType.Error;
    }
}

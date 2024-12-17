using BusinessLayer.Models.Communication.Messages.Messages.Enums;

namespace BusinessLayer.Models.Communication.Messages.Messages.Specific
{
    public record WarningMessage : MessageBase
    {
        public override MessageType Type => MessageType.Warning;
    }
}

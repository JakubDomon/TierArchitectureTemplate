using Domain.DTO.Messages.Enums;

namespace Domain.DTO.Messages.Specific
{
    public record WarningMessage(string Code, string Message) : MessageBase(Code, Message)
    {
        public override MessageType Type => MessageType.Warning;
    }
}

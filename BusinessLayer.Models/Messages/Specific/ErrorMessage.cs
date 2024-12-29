using Domain.DTO.Messages.Enums;

namespace Domain.DTO.Messages.Specific
{
    public record ErrorMessage(string Code, string Message) : MessageBase(Code, Message)
    {
        public override MessageType Type => MessageType.Error;
    }
}

using BusinessLayer.Models.Communication.Messages.Messages.Enums;

namespace BusinessLayer.Models.Communication.Messages.Messages.Specific
{
    public class ErrorMessage(string code, string message) : MessageBase(code, message)
    {
        public override MessageType Type => MessageType.Error;
    }
}

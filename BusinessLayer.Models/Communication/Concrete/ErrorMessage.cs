using BusinessLayer.Models.Communication.Enums;

namespace BusinessLayer.Models.Communication.Concrete
{
    public class ErrorMessage(string code, string message) : MessageBase(code, message)
    {
        public override MessageType Type => MessageType.Error;
    }
}

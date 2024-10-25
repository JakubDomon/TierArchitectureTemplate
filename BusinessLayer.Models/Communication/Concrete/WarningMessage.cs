using BusinessLayer.Models.Communication.Enums;

namespace BusinessLayer.Models.Communication.Concrete
{
    public class WarningMessage(string code, string message) : MessageBase(code, message)
    {
        public override MessageType Type => MessageType.Warning;
    }
}

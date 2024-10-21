using BusinessLayer.Models.Communication.Enums;

namespace BusinessLayer.Models.Communication.Concrete
{
    public class Message : IMessage
    {
        public int Code { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public MessageType Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IMessage.Message { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}

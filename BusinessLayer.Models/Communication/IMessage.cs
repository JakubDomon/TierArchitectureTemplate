using BusinessLayer.Models.Communication.Enums;

namespace BusinessLayer.Models.Communication
{
    public interface IMessage
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public MessageType Type { get; set; }
    }
}

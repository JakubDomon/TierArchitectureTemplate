using BusinessLayer.Models.Communication.Messages.Messages;
using BusinessLayer.Models.Communication.Messages.Messages.Enums;

namespace BusinessLayer.Models.Communication.Validation.Specific
{
    public class ValidationResult
    {
        public IEnumerable<IMessage> Messages { get; set; } = [];
        public bool IsSucceded
        {
            get => Messages.Any(m => m.Type == MessageType.Error);
        }
    }
}

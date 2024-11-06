using BusinessLayer.Models.Communication.Enums;

namespace BusinessLayer.Models.Communication.Concrete.Validation
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

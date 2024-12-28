using BusinessLayer.Models.Communication.Messages.Messages;
using BusinessLayer.Models.Communication.Messages.Messages.Enums;

namespace BusinessLayer.Models.Communication.Messages.Responses.Common
{
    public record UnifiedResponse<ResponseData>
        where ResponseData : ResponseBase
    {
        public ResponseData? Data { get; set; }
        public IEnumerable<IMessage> Messages { get; set; } = [];
        public bool IsSuccess
        {
            get => !Messages.Any(x => x.Type == MessageType.Error)
                && Data != null;
        }
    }
}

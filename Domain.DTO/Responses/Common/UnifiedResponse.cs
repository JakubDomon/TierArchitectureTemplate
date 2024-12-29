using Domain.DTO.Messages;
using Domain.DTO.Messages.Enums;
using Domain.DTO.Responses;

namespace Domain.DTO.Responses.Common
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

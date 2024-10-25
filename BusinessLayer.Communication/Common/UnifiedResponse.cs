using BusinessLayer.Models.Communication;
using BusinessLayer.Models.Communication.Enums;

namespace BusinessLayer.Communication.Common
{
    public class UnifiedResponse<ResponseData>
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

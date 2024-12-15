namespace BusinessLayer.Models.Communication.Messages.Requests.Common
{
    public class UnifiedRequest<RequestData>
        where RequestData : RequestBase
    {
        public required RequestData Data { get; set; }
    }
}

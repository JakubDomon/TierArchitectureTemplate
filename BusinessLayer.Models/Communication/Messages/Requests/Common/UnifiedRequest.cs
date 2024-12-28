namespace BusinessLayer.Models.Communication.Messages.Requests.Common
{
    public record UnifiedRequest<RequestData>
        where RequestData : RequestBase
    {
        public required RequestData Data { get; set; }
    }
}

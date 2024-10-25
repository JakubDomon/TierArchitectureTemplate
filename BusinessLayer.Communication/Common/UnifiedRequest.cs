namespace BusinessLayer.Communication.Common
{
    public class UnifiedRequest<RequestData>
        where RequestData : RequestBase
    {
        public required RequestData Data { get; set; }
    }
}

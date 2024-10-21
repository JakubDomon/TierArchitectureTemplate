namespace BusinessLayer.Communication
{
    public abstract class UnifiedRequest<RequestData>
        where RequestData : class
    {
        public RequestData? Data { get; set; }
    }
}

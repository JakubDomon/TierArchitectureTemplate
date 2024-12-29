namespace DataAccess.DTO.CommunicationObjects
{
    public class DataOperationResult<T>
    {
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
    }
}

namespace DataAccessLayer.DTO.CommunicationObjects
{
    public class DataOperationResult<T>
        where T : BaseDTO?
    {
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
    }
}

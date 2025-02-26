using System.Collections;

namespace DataAccess.DTO.CommunicationObjects
{
    public record DataOperationResult<T>
    {
        public bool IsSuccess 
        { 
            get 
            {
                if (Data is null)
                    return false;

                if(typeof(T) is ICollection collection)
                {
                    return collection.Count > 0;
                }

                return true;
            } 
        }
        public T? Data { get; init; }
    }
}

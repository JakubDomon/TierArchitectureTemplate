using DataAccess.DTO.CommunicationObjects;

namespace DataAccess.Repositories
{
    public abstract class RepositoryBase
    {
        protected DataOperationResult<T> CreateSuccessResponse<T>(T? data)
        {
            return new()
            {
                IsSuccess = true,
                Data = data,
            };
        }

        protected DataOperationResult<T> CreateErrorResponse<T>()
        {
            return new()
            {
                IsSuccess = false,
                Data = default,
            };
        }
    }
}

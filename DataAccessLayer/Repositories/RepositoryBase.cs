using DataAccessLayer.DTO;
using DataAccessLayer.DTO.CommunicationObjects;

namespace DataAccessLayer.Repositories
{
    public abstract class RepositoryBase
    {
        protected DataOperationResult<T> CreateSuccessResponse<T>(T? data)
            where T : BaseDTO 
        {
            return new()
            {
                IsSuccess = true,
                Data = data,
            };
        }

        protected DataOperationResult<T> CreateErrorResponse<T>()
            where T : BaseDTO
        {
            return new()
            {
                IsSuccess = false,
                Data = default,
            };
        }
    }
}

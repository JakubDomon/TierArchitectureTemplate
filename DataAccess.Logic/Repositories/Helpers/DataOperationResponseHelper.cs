using DataAccess.DTO.CommunicationObjects;

namespace DataAccess.Logic.Repositories.Helpers
{
    internal static class DataOperationResponseHelper
    {
        public static DataOperationResult<TDto> CreateResponse<TDto>(TDto? data, bool isSuccess) => new()
        {
            Data = data,
            IsSuccess = isSuccess
        };
    }
}

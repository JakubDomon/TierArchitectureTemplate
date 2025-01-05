using DataAccess.DTO.CommunicationObjects;

namespace DataAccess.Logic.Repositories.Helpers
{
    internal static class DataOperationResponseHelper
    {
        public static DataOperationResult<TDto> CreateResponse<TDto>(TDto? data = default) => new()
        {
            Data = data
        };
    }
}

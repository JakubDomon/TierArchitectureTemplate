using DataAccess.DTO.Common.CommunicationObjects.Enums;
using DataAccess.DTO.CommunicationObjects;

namespace DataAccess.Logic.Repositories.Helpers
{
    internal static class DataOperationResponseHelper
    {
        public static DataOperationResult<TDto> CreateResponse<TDto>(TDto? data = default, OperationDetail operationResult = default) => new()
        {
            Data = data,
            OperationDetail = operationResult,
        };
    }
}

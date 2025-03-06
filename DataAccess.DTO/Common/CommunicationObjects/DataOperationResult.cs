using DataAccess.DTO.Common.CommunicationObjects.Enums;
using DataAccess.DTO.Common.CommunicationObjects.Helpers;
using System.Collections;

namespace DataAccess.DTO.CommunicationObjects
{
    public record DataOperationResult<T>
    {
        public OperationDetail OperationDetail { get; init; }

        public bool IsSuccess => DataOperationResultHelper.SuccessOperationDetails.Contains(OperationDetail);

        public T? Data { get; init; }
    }
}

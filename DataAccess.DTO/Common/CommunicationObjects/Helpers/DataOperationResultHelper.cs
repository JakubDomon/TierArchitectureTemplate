using DataAccess.DTO.Common.CommunicationObjects.Enums;

namespace DataAccess.DTO.Common.CommunicationObjects.Helpers
{
    internal static class DataOperationResultHelper
    {
        public static readonly List<OperationDetail> SuccessOperationDetails = [OperationDetail.Ok, OperationDetail.Created, OperationDetail.NoContent];
    }
}

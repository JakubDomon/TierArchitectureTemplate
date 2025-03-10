using Domain.DTO.Common.Enums;

namespace Domain.DTO.Common.Helpers
{
    public static class OperationDetailHelper
    {
        private static readonly List<OperationDetail> SuccessOperationDetails = [ OperationDetail.Ok, OperationDetail.Created, OperationDetail.NoContent ];
        public static bool IsSuccess(OperationDetail operationDetail) => SuccessOperationDetails.Contains(operationDetail);
    }
}

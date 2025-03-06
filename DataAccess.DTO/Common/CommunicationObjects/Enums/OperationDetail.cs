namespace DataAccess.DTO.Common.CommunicationObjects.Enums
{
    public enum OperationDetail
    {
        Undefined = 0,

        /// Success
        Ok = 1,
        Created = 2,
        NoContent = 3,

        /// Error
        Error = 4,
        BadRequest = 5,
        Conflict = 6,
        NotFound = 7,
        Unauthorized = 8,
    }
}

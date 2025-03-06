using Common.Core.Attributes;

namespace Common.Models.Communication.Enums
{
    public enum OperationResult
    {
        [IntValue(0)]
        Undefined = 0,
        
        [IntValue(201)]
        Created = 1,

        [IntValue(400)]
        BadRequest = 2,

        [IntValue(409)]
        Conflict = 3,

        [IntValue(200)]
        Ok = 4,

        [IntValue(204)]
        NoContent = 5,

        [IntValue(404)]
        NotFound = 6,

        [IntValue(401)]
        Unauthorized = 7,

        [IntValue(403)]
        Forbidden = 8,

        [IntValue(500)]
        ServerError = 9,
    }
}

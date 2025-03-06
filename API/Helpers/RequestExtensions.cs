using Domain.DTO.Common;
using System.Runtime.CompilerServices;

namespace API.Helpers
{
    public static class RequestExtensions
    {
        public static UnifiedRequest<T> WrapAsUnifiedRequest<T>(this T source)
            where T: IAction => new(source);
    }
}

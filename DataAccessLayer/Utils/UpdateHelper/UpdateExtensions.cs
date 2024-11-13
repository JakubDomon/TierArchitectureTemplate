namespace DataAccessLayer.Utils.UpdateHelper
{
    internal static class UpdateExtensions
    {
        public static UpdateHelper<T> Update<T>(this T targetObject, T dataObject)
            where T : IFluentUpdatable
        {
            return new UpdateHelper<T>(targetObject, dataObject);
        }
    }
}

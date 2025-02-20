namespace Domain.Logic.Resources.Messages.Helpers
{
    internal static class MessageHelperExtensions
    {
        public static string FillMessage(this string message, params object[] args)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException("Message templace cannot be null or empty", nameof(message));
            }

            return string.Format(message, args);
        }
    }
}

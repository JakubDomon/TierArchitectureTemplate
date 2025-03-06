using Common.Core.Attributes;
using System.Reflection;

namespace Common.Core.Extensions
{
    public static class EnumExtensions
    {
        public static int? GetIntValue(this Enum source)
        {
            var member = source.GetType()
                            .GetMember(source.ToString())
                            .FirstOrDefault();
            var attribute = member?.GetCustomAttribute<IntValueAttribute>();

            return attribute?.Value;
        }
    }
}

namespace Common.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class IntValueAttribute(int value) : Attribute
    {
        public int Value { get; } = value;
    }
}

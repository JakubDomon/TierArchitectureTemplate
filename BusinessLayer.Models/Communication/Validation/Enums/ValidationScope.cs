using EnumStringValues;

namespace BusinessLayer.Models.Communication.Validation.Enums
{
    public enum ValidationScope
    {
        [StringValue("None")]
        None = 0,

        [StringValue("UserValidation")]
        UserValidation = 1,
    }
}

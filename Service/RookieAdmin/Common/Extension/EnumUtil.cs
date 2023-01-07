using System.ComponentModel;

namespace RookieAdmin.Common.Extension
{
    public static class EnumUtil
    {
        public static string GetDescriptionFromEnumValue(this Enum value)
        {
            if (value == null) throw new ArgumentNullException("方法引數不可為空，兄弟");

            DescriptionAttribute? attribute = value.GetType()?
                .GetField(value.ToString())?
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .SingleOrDefault() as DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}

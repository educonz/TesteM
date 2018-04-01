using System;
using System.ComponentModel;
using System.Linq;

namespace Domain.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum enumValue)
        {
            var type = enumValue.GetType();
            var fieldInfo = type.GetField(enumValue.ToString());
            var attributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Any())
            {
                var attribute = attributes.Cast<DescriptionAttribute>().First();
                return attribute.Description;
            }
            return enumValue.ToString();
        }
    }
}

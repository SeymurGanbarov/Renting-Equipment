using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Common.Util
{
    public static class EnumExtensions
    {
        private static string LookupResource(IReflect resourceManagerProvider, string resourceKey)
        {
            foreach (var staticProperty in resourceManagerProvider.GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public))
            {
                if (staticProperty.PropertyType == typeof(System.Resources.ResourceManager))
                {
                    var resourceManager = (System.Resources.ResourceManager)staticProperty.GetValue(null, null);
                    return resourceManager.GetString(resourceKey);
                }
            }
            return resourceKey; // Fallback with the key name
        }

        public static string GetDisplayName<T>(this T value) where T : struct
        {
            var type = value.GetType();
            var fieldInfo = type.GetField(value.ToString());
            if (fieldInfo == null) return Enum.GetName(type, value);

            if (!(fieldInfo.GetCustomAttributes(
                    typeof(DisplayAttribute), false) is DisplayAttribute[] descriptionAttributes)
                || descriptionAttributes.Length == 0) return value.ToString();

            if (descriptionAttributes[0].ResourceType != null)
                return LookupResource(descriptionAttributes[0].ResourceType, descriptionAttributes[0].Name);

            return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Name : value.ToString();
        }

        public static string GetDescription<T>(this T enumerationValue) where T : struct
        {
            var type = enumerationValue.GetType();
            if (!type.IsEnum)
                throw new ArgumentException(@"EnumerationValue must be of Enum type", nameof(enumerationValue));
            var memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo.Length <= 0) return enumerationValue.ToString();
            var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attrs.Length > 0 ? ((DescriptionAttribute)attrs[0]).Description : enumerationValue.ToString();
        }

        public static TEnum ToEnum<TEnum>(this string value)
            where TEnum : struct
        {
            if (string.IsNullOrEmpty(value))
                return default(TEnum);

            TEnum result;
            return Enum.TryParse<TEnum>(value, true, out result) ? result : default(TEnum);
        }
    }
}

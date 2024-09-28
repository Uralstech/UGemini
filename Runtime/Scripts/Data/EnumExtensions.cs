using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace Uralstech.UGemini
{
    /// <summary>
    /// Extensions for <see cref="Enum"/> type objects.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Converts an <see cref="Enum"/> to the value defined in its <see cref="EnumMemberAttribute">
        /// </summary>
        /// <param name="enumValue">The enum value.</param>
        /// <returns>The value.</returns>
        /// <exception cref="NotImplementedException">Thrown if an <see cref="EnumMemberAttribute"> for the enum value could not be found.</exception>
        public static string EnumMemberValue(this Enum enumValue)
        {
            Type type = enumValue.GetType();
            MemberInfo[] memberInfo = type.GetMember(enumValue.ToString());

            if (memberInfo != null && memberInfo.Length > 0)
            {
                Attribute attribute = memberInfo[0].GetCustomAttribute(typeof(EnumMemberAttribute));
                if (attribute is EnumMemberAttribute enumMemberAttribute)
                    return enumMemberAttribute.Value;
            }

            // Throw error if no EnumMember attribute is found.
            throw new NotImplementedException($"No {nameof(EnumMemberAttribute)} found for \"{type.Name}.{enumValue}\"!");
        }
    }
}
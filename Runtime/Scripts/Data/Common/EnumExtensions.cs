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
        /// Converts a <see cref="GeminiContentType"/> to its <see href="https://www.iana.org/assignments/media-types/media-types.xhtml">MIME type</see>.
        /// </summary>
        /// <param name="enumValue">The <see cref="GeminiContentType"/> value.</param>
        /// <returns>The MIME type as a string.</returns>
        public static string MimeType(this GeminiContentType enumValue)
        {
            Type type = enumValue.GetType();
            MemberInfo[] memberInfo = type.GetMember(enumValue.ToString());

            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attributes = memberInfo[0].GetCustomAttributes(typeof(EnumMemberAttribute), false);

                if (attributes != null && attributes.Length > 0)
                    return ((EnumMemberAttribute)attributes[0]).Value;
            }

            // Return the enum name if no EnumMember attribute is found
            return enumValue.ToString();
        }
    }
}
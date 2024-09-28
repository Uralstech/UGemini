using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace Uralstech.UGemini
{
    /// <summary>
    /// Extensions for <see cref="GeminiContentType"/>.
    /// </summary>
    public static class GeminiContentTypeExtensions
    {
        /// <summary>
        /// Converts a <see cref="GeminiContentType"/> to its <a href="https://www.iana.org/assignments/media-types/media-types.xhtml">MIME type</a>.
        /// </summary>
        /// <param name="enumValue">The <see cref="GeminiContentType"/> value.</param>
        /// <returns>The MIME type as a string.</returns>
        /// <exception cref="NotImplementedException">Thrown if the MIME type of the enum value could not be found.</exception>
        public static string MimeType(this GeminiContentType enumValue)
        {
            return enumValue.EnumMemberValue();
        }

        /// <summary>
        /// Converts a <see cref="string"/> MIME type to a <see cref="GeminiContentType"/>.
        /// </summary>
        /// <param name="mimeType">The MIME type string.</param>
        /// <returns>The <see cref="GeminiContentType"/> equivalent.</returns>
        /// <exception cref="NotImplementedException">Thrown if <see cref="GeminiContentType"/> does not have an equivalent MIME type to <paramref name="mimeType"/>.</exception>
        public static GeminiContentType ContentType(this string mimeType)
        {
            Type type = typeof(GeminiContentType);
            foreach (string name in Enum.GetNames(type))
            {
                MemberInfo[] memberInfo = type.GetMember(name);
                if (memberInfo != null && memberInfo.Length > 0)
                {
                    EnumMemberAttribute enumMemberAttribute = memberInfo[0].GetCustomAttribute<EnumMemberAttribute>();
                    if (enumMemberAttribute != null && enumMemberAttribute.Value == mimeType)
                        return (GeminiContentType)Enum.Parse(type, name);
                }
            }

            // Throw error if no enum value is found.
            throw new NotImplementedException($"No {nameof(GeminiContentType)} found for MIME type \"{mimeType}\"!");
        }
    }
}
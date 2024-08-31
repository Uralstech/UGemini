﻿using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace Uralstech.UGemini
{
    /// <summary>
    /// Extensions for <see cref="Enum"/> type objects.
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
            Type type = typeof(GeminiContentType);
            MemberInfo[] memberInfo = type.GetMember(enumValue.ToString());

            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attributes = memberInfo[0].GetCustomAttributes(typeof(EnumMemberAttribute), false);

                if (attributes != null && attributes.Length > 0)
                    return ((EnumMemberAttribute)attributes[0]).Value;
            }

            // Throw error if no EnumMember attribute is found.
            throw new NotImplementedException($"No {nameof(EnumMemberAttribute)} found for content type \"{enumValue}\"!");
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
                    object[] attributes = memberInfo[0].GetCustomAttributes(typeof(EnumMemberAttribute), false);
                    if (attributes != null && attributes.Length > 0 && ((EnumMemberAttribute)attributes[0]).Value == mimeType)
                        return (GeminiContentType)Enum.Parse(type, name);
                }
            }

            // Throw error if no enum value is found.
            throw new NotImplementedException($"No {nameof(GeminiContentType)} found for MIME type \"{mimeType}\"!");
        }
    }
}
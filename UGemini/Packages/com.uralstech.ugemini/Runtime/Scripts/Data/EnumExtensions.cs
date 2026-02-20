// Copyright 2024 URAV ADVANCED LEARNING SYSTEMS PRIVATE LIMITED
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

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
        /// Converts an <see cref="Enum"/> to the value defined in its <see cref="EnumMemberAttribute"/>.
        /// </summary>
        /// <param name="enumValue">The enum value.</param>
        /// <returns>The value.</returns>
        /// <exception cref="NotImplementedException">Thrown if an <see cref="EnumMemberAttribute"/> could not be found on the enum value.</exception>
        public static string EnumMemberValue(this Enum enumValue)
        {
            Type type = enumValue.GetType();
            MemberInfo[] memberInfo = type.GetMember(enumValue.ToString());

            if (memberInfo != null && memberInfo.Length > 0)
            {
                EnumMemberAttribute enumMemberAttribute = memberInfo[0].GetCustomAttribute<EnumMemberAttribute>();
                if (enumMemberAttribute != null)
                    return enumMemberAttribute.Value;
            }

            // Throw error if no EnumMember attribute is found.
            throw new NotImplementedException($"No {nameof(EnumMemberAttribute)} found for \"{type.Name}.{enumValue}\"!");
        }
    }
}
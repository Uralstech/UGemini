using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Uralstech.UGemini.Models
{
    /// <summary>
    /// Extension to generate a <a href="https://protobuf.dev/reference/protobuf/google.protobuf/#field-mask">Field Mask</a> from any object.
    /// </summary>
    public static class GeminiFieldMaskGenerator
    {
        /// <summary>
        /// Binding flags for accessing public instance members.
        /// </summary>
        private static readonly BindingFlags s_publicInstanceMembers = BindingFlags.Instance | BindingFlags.Public;

        /// <summary>
        /// Generates a <a href="https://protobuf.dev/reference/protobuf/google.protobuf/#field-mask">Field Mask</a> from an object of type <typeparamref name="T"/>.
        /// </summary>
        /// <remarks>
        /// This is a reflection heavy process. Also, this only works if the default value off all fields and properties in <typeparamref name="T"/> is <see langword="null"/>.
        /// </remarks>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="thiz">The object.</param>
        /// <returns>A string field mask.</returns>
        /// <exception cref="NotImplementedException">Thrown if <typeparamref name="T"/> does not implement <see cref="JsonObjectAttribute"/> or has no defined <see cref="NamingStrategy"/>.</exception>
        public static string GetFieldMask<T>(this T thiz)
        {
            Type type = typeof(T);

            JsonObjectAttribute jsonObjectAttribute = type.GetCustomAttribute<JsonObjectAttribute>()
                ?? throw new NotImplementedException($"Cannot get field mask for object of type {type.Name} as it does not implement {nameof(JsonObjectAttribute)}!");

            if (jsonObjectAttribute.NamingStrategyType is not Type namingStrategyType)
                throw new NotImplementedException($"Cannot get field mask for object of type {type.Name} as it has no defined {nameof(NamingStrategy)}.");

            NamingStrategy namingStrategy = (NamingStrategy)Activator.CreateInstance(namingStrategyType);
            PropertyInfo[] properties = type.GetProperties(s_publicInstanceMembers);
            FieldInfo[] fields = type.GetFields(s_publicInstanceMembers);

            IEnumerable<string> filledProperties = from property in properties
                                                   where property.GetValue(thiz) != null
                                                   select GetJsonMemberName(property, namingStrategy);

            IEnumerable<string> filledFields = from field in fields
                                               where field.GetValue(thiz) != null
                                               select GetJsonMemberName(field, namingStrategy);

            return string.Join(",", filledProperties.Concat(filledFields));
        }

        /// <summary>
        /// Gets the JSON name of a type member as defined in its <see cref="JsonPropertyAttribute"/>, or uses a <see cref="NamingStrategy"/> to convert its name.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <param name="namingStrategy">The naming strategy to use if a defined JSON name was not found.</param>
        /// <returns>The JSON name of the member.</returns>
        private static string GetJsonMemberName(MemberInfo member, NamingStrategy namingStrategy)
        {
            JsonPropertyAttribute jsonPropertyAttribute = member.GetCustomAttribute<JsonPropertyAttribute>();
            return jsonPropertyAttribute != null && !string.IsNullOrEmpty(jsonPropertyAttribute.PropertyName) ? jsonPropertyAttribute.PropertyName : namingStrategy.GetPropertyName(member.Name, false);
        }
    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.ComponentModel;
using UnityEngine;
using Uralstech.UGemini.Tools;

namespace Uralstech.UGemini
{
    /// <summary>
    /// The base structured datatype containing multi-part content of a message.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiContent
    {
        /// <summary>
        /// Ordered Parts that constitute a single message. Parts may have different MIME types.
        /// </summary>
        public GeminiContentPart[] Parts;

        /// <summary>
        /// Optional. The producer of the content.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(GeminiRole.Unspecified)]
        public GeminiRole Role = GeminiRole.Unspecified;

        /// <summary>
        /// Creates a new <see cref="GeminiContent"/> from a role and message.
        /// </summary>
        /// <param name="role">The role of the content creator.</param>
        /// <param name="message">The message.</param>
        /// <returns>A new <see cref="GeminiContent"/> object.</returns>
        public static GeminiContent GetContent(string message, GeminiRole role = GeminiRole.Unspecified)
        {
            return new GeminiContent
            {
                Role = role,
                Parts = new[]
                {
                    new GeminiContentPart
                    {
                        Text = message,
                    }
                }
            };
        }

        /// <summary>
        /// Creates a new <see cref="GeminiContent"/> from a role, message and <see cref="Texture2D"/>.
        /// </summary>
        /// <param name="role">The role of the content creator.</param>
        /// <param name="message">The message.</param>
        /// <param name="image">The image texture.</param>
        /// <returns>A new <see cref="GeminiContent"/> object.</returns>
        public static GeminiContent GetContent(string message, Texture2D image, GeminiRole role = GeminiRole.Unspecified)
        {
            return new()
            {
                Role = role,
                Parts = new[]
                {
                    new GeminiContentPart
                    {
                        Text = message,
                    },
                    new GeminiContentPart
                    {
                        InlineData = new()
                        {
                            MimeType = GeminiContentType.ImageJPEG,
                            Data = Convert.ToBase64String(image.EncodeToJPG())
                        }
                    }
                }
            };
        }

        /// <summary>
        /// Creates a new <see cref="GeminiContent"/> from a <see cref="GeminiFunctionCall"/>.
        /// </summary>
        /// <param name="functionCall">The function call.</param>
        /// <returns>A new <see cref="GeminiContent"/> object.</returns>
        public static GeminiContent GetContent(GeminiFunctionCall functionCall)
        {
            return new GeminiContent
            {
                Role = GeminiRole.Assistant,
                Parts = new[]
                {
                    new GeminiContentPart
                    {
                        FunctionCall = functionCall,
                    }
                }
            };
        }

        /// <summary>
        /// Creates a new <see cref="GeminiContent"/> from a <see cref="GeminiFunctionResponse"/>.
        /// </summary>
        /// <param name="functionResponse">The function response.</param>
        /// <returns>A new <see cref="GeminiContent"/> object.</returns>
        public static GeminiContent GetContent(GeminiFunctionResponse functionResponse)
        {
            return new GeminiContent
            {
                Role = GeminiRole.ToolResponse,
                Parts = new[]
                {
                    new GeminiContentPart
                    {
                        FunctionResponse = functionResponse,
                    }
                }
            };
        }
    }
}
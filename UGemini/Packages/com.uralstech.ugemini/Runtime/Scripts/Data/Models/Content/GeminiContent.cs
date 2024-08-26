using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Uralstech.UGemini.FileAPI;
using Uralstech.UGemini.Models.Generation.Tools;

namespace Uralstech.UGemini.Models.Content
{
    /// <summary>
    /// The base structured datatype containing multi-part content of a message.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiContent : IAppendableData<GeminiContent>
    {
        /// <summary>
        /// Ordered Parts that constitute a single message. Parts may have different MIME types.
        /// </summary>
        public GeminiContentPart[] Parts;

        /// <summary>
        /// Optional. The producer of the content.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(GeminiRole.Unspecified)]
        public GeminiRole Role;

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
                        InlineData = GeminiContentBlob.GetContentBlob(image),
                    },
                }
            };
        }

#if UTILITIES_ENCODING_WAV_1_0_0_OR_GREATER && UTILITIES_AUDIO_1_0_0_OR_GREATER
        /// <summary>
        /// Creates a new <see cref="GeminiContent"/> from a role, message and <see cref="AudioClip"/>.
        /// </summary>
        /// <remarks>
        /// Requires <a href="https://openupm.com/packages/com.utilities.encoder.wav/">Utilities.Encoding.Wav</a>.
        /// </remarks>
        /// <param name="role">The role of the content creator.</param>
        /// <param name="message">The message.</param>
        /// <param name="audio">The audio clip.</param>
        /// <returns>A new <see cref="GeminiContent"/> object.</returns>
        public static GeminiContent GetContent(string message, AudioClip audio, GeminiRole role = GeminiRole.Unspecified)
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
                        InlineData = GeminiContentBlob.GetContentBlob(audio),
                    }
                }
            };
        }
#endif

        /// <summary>
        /// Creates a new <see cref="GeminiContent"/> from a role, message and <see cref="GeminiFile"/>.
        /// </summary>
        /// <param name="role">The role of the content creator.</param>
        /// <param name="message">The message.</param>
        /// <param name="file">The <see cref="GeminiFile"/>.</param>
        /// <returns>A new <see cref="GeminiContent"/> object.</returns>
        public static GeminiContent GetContent(string message, GeminiFile file, GeminiRole role = GeminiRole.Unspecified)
        {
            return new GeminiContent
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
                        FileData = new GeminiFileData
                        {
                            MimeType = file.MimeType,
                            FileUri = file.Uri,
                        },
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

        /// <inheritdoc/>
        public void Append(GeminiContent data)
        {
            if (data.Role != default)
                Role = data.Role;

            if (data.Parts != null)
            {
                List<GeminiContentPart> partsToAdd = new();
                for (int i = 0; i < data.Parts.Length; i++)
                {
                    GeminiContentPart partToAppend = data.Parts[i];
                    bool appended = false;

                    for (int j = 0; j < Parts.Length; j++)
                    {
                        GeminiContentPart part = Parts[j];
                        if (part.IsAppendable(partToAppend))
                        {
                            part.Append(partToAppend);
                            appended = true;
                        }
                    }

                    if (!appended)
                        partsToAdd.Add(partToAppend);
                }

                if (partsToAdd.Count > 0)
                {
                    GeminiContentPart[] allParts = new GeminiContentPart[Parts.Length + partsToAdd.Count];
                    Parts.CopyTo(allParts, 0);

                    partsToAdd.CopyTo(allParts, Parts.Length);
                    Parts = allParts;
                }
            }
        }
    }
}
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using UnityEngine;
using System;

namespace Uralstech.GeminiAPI.Data
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiContent
    {
        public GeminiContentPart[] Parts;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public GeminiRole Role;

        public static GeminiContent GetNew(GeminiRole role, string message)
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

        public static GeminiContent GetNew(GeminiRole role, string message, Texture2D image)
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
    }
}
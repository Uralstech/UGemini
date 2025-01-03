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

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.UGemini.Models.Generation.Safety
{
    /// <summary>
    /// The category of a rating.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiSafetyHarmCategory
    {
        /// <summary>
        /// Category is unspecified.
        /// </summary>
        [EnumMember(Value = "HARM_CATEGORY_UNSPECIFIED")]
        Unspecified,

        /// <summary>
        /// Negative or harmful comments targeting identity and/or protected attribute.
        /// </summary>
        [EnumMember(Value = "HARM_CATEGORY_DEROGATORY")]
        Derogatory,

        /// <summary>
        /// Content that is rude, disrespectful, or profane.
        /// </summary>
        [EnumMember(Value = "HARM_CATEGORY_TOXICITY")]
        Toxicity,

        /// <summary>
        /// Describes scenarios depicting violence against an individual or group, or general descriptions of gore.
        /// </summary>
        [EnumMember(Value = "HARM_CATEGORY_VIOLENCE")]
        Violence,

        /// <summary>
        /// Contains references to sexual acts or other lewd content.
        /// </summary>
        [EnumMember(Value = "HARM_CATEGORY_SEXUAL")]
        Sexual,

        /// <summary>
        /// Promotes unchecked medical advice.
        /// </summary>
        [EnumMember(Value = "HARM_CATEGORY_MEDICAL")]
        Medical,

        /// <summary>
        /// Dangerous content that promotes, facilitates, or encourages harmful acts.
        /// </summary>
        [EnumMember(Value = "HARM_CATEGORY_DANGEROUS")]
        Dangerous,

        /// <summary>
        /// Harasment content.
        /// </summary>
        [EnumMember(Value = "HARM_CATEGORY_HARASSMENT")]
        Harassment,

        /// <summary>
        /// Hate speech and content.
        /// </summary>
        [EnumMember(Value = "HARM_CATEGORY_HATE_SPEECH")]
        HateSpeech,

        /// <summary>
        /// Sexually explicit content.
        /// </summary>
        [EnumMember(Value = "HARM_CATEGORY_SEXUALLY_EXPLICIT")]
        SexuallyExplicit,

        /// <summary>
        /// Dangerous content.
        /// </summary>
        [EnumMember(Value = "HARM_CATEGORY_DANGEROUS_CONTENT")]
        DangerousContent,

        /// <summary>
        /// Content that may be used to harm civic integrity.
        /// </summary>
        [EnumMember(Value = "HARM_CATEGORY_CIVIC_INTEGRITY")]
        CivicIntegrity,
    }
}
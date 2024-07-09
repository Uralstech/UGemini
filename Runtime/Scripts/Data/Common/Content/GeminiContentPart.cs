﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;
using Uralstech.UGemini.Tools;

namespace Uralstech.UGemini
{
    /// <summary>
    /// A datatype containing media that is part of a multi-part Content message. Must only contain one field at a time.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiContentPart : IAppendableData<GeminiContentPart>
    {
        /// <summary>
        /// Inline text.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public string Text = null;

        /// <summary>
        /// Inline media bytes.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiContentBlob InlineData = null;

        /// <summary>
        /// A predicted FunctionCall returned from the model that contains a string representing the FunctionDeclaratio.name with the arguments and their values.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiFunctionCall FunctionCall = null;

        /// <summary>
        /// The result output of a FunctionCall that contains a string representing the FunctionDeclaration.name and a structured JSON object containing any output from the function is used as context to the model.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiFunctionResponse FunctionResponse = null;

        /// <summary>
        /// URI based data.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiFileData FileData = null;

        /// <inheritdoc/>
        public void Append(GeminiContentPart data)
        {
            if (string.IsNullOrEmpty(Text))
                Text = data.Text;
            else if (!string.IsNullOrEmpty(data.Text))
                Text += data.Text;

            if (data.InlineData != null)
                InlineData = data.InlineData;

            if (data.FunctionCall != null)
                FunctionCall = data.FunctionCall;

            if (data.FunctionResponse != null)
                FunctionResponse = data.FunctionResponse;

            if (data.FileData != null)
                FileData = data.FileData;
        }

        /// <summary>
        /// Is the data to be appended compatible with the current <see cref="GeminiContentPart"/>?
        /// </summary>
        /// <param name="data">The data to be appended.</param>
        public bool IsAppendable(GeminiContentPart data)
        {
            return IsEmpty || data switch
            {
                { Text: string text } when !string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(Text) => true,
                { InlineData: not null } when InlineData != null => data.InlineData.MimeType == InlineData.MimeType,
                { FunctionCall: not null } when FunctionCall != null => data.FunctionCall.Name == FunctionCall.Name,
                { FunctionResponse: not null } when FunctionResponse != null => data.FunctionResponse.Name == FunctionResponse.Name,
                { FileData: not null } when FileData != null => data.FileData.FileUri == FileData.FileUri,
                _ => false,
            };
        }

        /// <summary>
        /// Is there no content stored in this <see cref="GeminiContentPart"/>?
        /// </summary>
        [JsonIgnore]
        public bool IsEmpty => string.IsNullOrEmpty(Text)
            && InlineData == null
            && FunctionCall == null
            && FunctionResponse == null
            && FileData == null;
    }
}
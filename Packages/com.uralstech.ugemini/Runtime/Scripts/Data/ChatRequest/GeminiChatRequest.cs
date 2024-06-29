using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Uralstech.GeminiAPI.Data.ChatRequest
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiChatRequest
    {
        public GeminiContent[] Contents;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public GeminiTool[] Tools;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public GeminiToolConfiguration ToolConfig;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public GeminiSafetySettings[] SafetySettings;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public GeminiContent SystemInstruction;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public GeminiGenerationConfiguration GenerationConfig;
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiFunctionCallingMode
    {
        [EnumMember(Value = "MODE_UNSPECIFIED")]
        Unspecified,

        [EnumMember(Value = "AUTO")]
        Auto,

        [EnumMember(Value = "ANY")]
        Any,

        [EnumMember(Value = "NONE")]
        None,
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiFunctionDataType
    {
        [EnumMember(Value = "TYPE_UNSPECIFIED")]
        Unspecified,

        [EnumMember(Value = "STRING")]
        String,

        [EnumMember(Value = "NUMBER")]
        Float,

        [EnumMember(Value = "INTEGER")]
        Integer,

        [EnumMember(Value = "BOOLEAN")]
        Boolean,

        [EnumMember(Value = "ARRAY")]
        Array,

        [EnumMember(Value = "OBJECT")]
        Object,
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiTool
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public GeminiFunctionDeclaration[] FunctionDeclarations;
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiFunctionDeclaration
    {
        public string Name;
        public string Description;
        public GeminiFunctionSchema Parameters;
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiFunctionSchema
    {
        public GeminiFunctionDataType Type;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Format;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Description;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Nullable;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string[] Enum;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Dictionary<string, GeminiFunctionSchema> Properties;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string[] Required;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public GeminiFunctionSchema Items;
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiToolConfiguration
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public GeminiFunctionCallingConfiguration FunctionCallingConfig;
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiFunctionCallingConfiguration
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public GeminiFunctionCallingMode Mode;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string[] AllowedFunctionNames;
    }
}
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
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Generation.Candidate.GroundingMetadata
{
    /// <summary>
    /// Google search entry point.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy), ItemNullValueHandling = NullValueHandling.Ignore)]
    public class GeminiSearchEntryPoint
    {
        /// <summary>
        /// Web content snippet that can be embedded in a web page or an app webview.
        /// </summary>
        public string RenderedContent = null;

        /// <summary>
        /// Base64 encoded JSON representing array of &lt;search term, search url&gt; tuple.
        /// </summary>
        public string SdkBlob = null;
    }
}

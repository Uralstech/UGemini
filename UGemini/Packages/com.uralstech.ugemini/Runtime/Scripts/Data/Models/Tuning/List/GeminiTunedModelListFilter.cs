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

using System.Runtime.Serialization;

namespace Uralstech.UGemini.Models.Tuning
{
    /// <summary>
    /// Simple filter to get models by account authorization.
    /// </summary>
    public enum GeminiTunedModelListFilter
    {
        /// <summary>
        /// Default value.
        /// </summary>
        None,

        /// <summary>
        /// Returns all tuned models to which caller has owner role.
        /// </summary>
        [EnumMember(Value = "owner:me")]
        IAmOwner,

        /// <summary>
        /// Returns all tuned models to which caller has writer role.
        /// </summary>
        [EnumMember(Value = "writers:me")]
        IAmWriter,

        /// <summary>
        /// Returns all tuned models to which caller has reader role.
        /// </summary>
        [EnumMember(Value = "readers:me")]
        IAmReader,

        /// <summary>
        /// Returns all tuned models to which caller has reader role.
        /// </summary>
        [EnumMember(Value = "readers:everyone")]
        EveryoneIsReader
    }
}

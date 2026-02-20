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

namespace Uralstech.UGemini
{
    /// <summary>
    /// An interface for data that is to be appended to at runtime.
    /// </summary>
    /// <typeparam name="T">The type that can be appended to the <see cref="IAppendableData{T}"/>.</typeparam>
    public interface IAppendableData<T>
    {
        /// <summary>
        /// Appends the <paramref name="data"/> to the current <see cref="IAppendableData{T}"/>.
        /// </summary>
        /// <param name="data">The data to append.</param>
        public void Append(T data);
    }
}

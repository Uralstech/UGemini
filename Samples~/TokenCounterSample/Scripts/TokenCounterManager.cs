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

using UnityEngine;
using UnityEngine.UI;
using Uralstech.UGemini.Models;
using Uralstech.UGemini.Models.Content;
using Uralstech.UGemini.Models.CountTokens;

namespace Uralstech.UGemini.Samples
{
    public class TokenCounterManager : MonoBehaviour
    {
        [SerializeField] private bool _useBeta;
        [SerializeField] private InputField _contentInput;
        [SerializeField] private Text _response;

        public async void OnCount()
        {
            string text = _contentInput.text;
            if (string.IsNullOrWhiteSpace(text))
            {
                Debug.LogError("Chat text should not be null or whitespace!");
                return;
            }

            GeminiTokenCountResponse response = await GeminiManager.Instance.Request<GeminiTokenCountResponse>(new GeminiTokenCountRequest(GeminiModel.Gemini1_5Flash, _useBeta)
            {
                Contents = new GeminiContent[]
                {
                    GeminiContent.GetContent(text, GeminiRole.User),
                },
            });
            
            _response.text = $"Tokens: {response.TotalTokens}";
        }
    }
}

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

using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Uralstech.UGemini.Models;
using Uralstech.UGemini.Models.Content;
using Uralstech.UGemini.Models.Generation.QuestionAnswering;
using Uralstech.UGemini.Models.Generation.QuestionAnswering.Grounding;
using Newtonsoft.Json;

namespace Uralstech.UGemini.Samples
{
    public class QuestionAnsweringManager : MonoBehaviour
    {
        [SerializeField] private bool _useBeta = true;
        [SerializeField] private InputField _chatInput;
        [SerializeField] private Text _answerText;
        [SerializeField, Multiline] private string _qaContext;

        private GeminiAnswerStyle _answerStyle = GeminiAnswerStyle.Abstractive;

        public void SetAnswerStyle(int style)
        {
            _answerStyle = (GeminiAnswerStyle)style;
        }

        public async void OnChat()
        {
            string text = _chatInput.text;
            if (string.IsNullOrWhiteSpace(text))
            {
                Debug.LogError("Chat text should not be null or whitespace!");
                return;
            }
    
            _chatInput.text = string.Empty;

#pragma warning disable IDE0090 // Use 'new(...)'
            GeminiAnswerResponse response = await GeminiManager.Instance.Request<GeminiAnswerResponse>(new GeminiAnswerRequest(GeminiModel.Aqa, _useBeta)
            {
                Contents = new GeminiContent[]
                {
                    GeminiContent.GetContent(text, GeminiRole.User)
                },
                AnswerStyle = _answerStyle,
                InlinePassages = new GeminiGroundingPassages()
                {
                    Passages = new GeminiGroundingPassage[]
                    {
                        new GeminiGroundingPassage()
                        {
                            Id = "qaContext",
                            Content = GeminiContent.GetContent(_qaContext)
                        }
                    }
                }
            });
#pragma warning restore IDE0090 // Use 'new(...)'

            if (response?.Answer?.Content?.Parts != null && response.Answer.Content.Parts.Length > 0)
                _answerText.text = response.Answer.Content.Parts[0]?.Text;
        }
    }
}

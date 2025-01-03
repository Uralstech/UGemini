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
using UnityEngine;
using UnityEngine.UI;
using Uralstech.UGemini.Models.Content;

namespace Uralstech.UGemini.Samples
{
    public class UIChatMessage : MonoBehaviour
    {
        [SerializeField] private Text _senderText;
        [SerializeField] private Text _messageText;
        [SerializeField] private RawImage _messageImage;
    
        public void Setup(GeminiContent content, bool isSystemPrompt)
        {
            if (content.Parts == null)
            {
                Debug.LogError("Content does not contain any parts!");
                return;
            }

            Texture2D image = new(1, 1);
            foreach (GeminiContentPart part in content.Parts)
            {
                if (part.Text != null)
                    _messageText.text = part.Text;
                else if (part.InlineData != null)
                {
                    switch (part.InlineData.MimeType)
                    {
                        case GeminiContentType.ImagePNG:
                        case GeminiContentType.ImageJPEG:
                            image.LoadImage(Convert.FromBase64String(part.InlineData.Data));
    
                            _messageImage.texture = image;
                            break;
    
                        default:
                            Debug.LogError($"Could not load data of type: {part.InlineData.MimeType}!");
                            break;
                    }
                }
            }
    
            _senderText.text = isSystemPrompt ? "System" : content.Role.ToString();
        }
    }
}

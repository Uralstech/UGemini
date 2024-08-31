using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Uralstech.UGemini.Models;
using Uralstech.UGemini.Models.Content;
using Uralstech.UGemini.Models.Generation;
using Uralstech.UGemini.Models.Generation.Chat;
using Uralstech.UGemini.Models.Generation.Schema;

namespace Uralstech.UGemini.Samples
{
    public class JSONChatManager : MonoBehaviour
    {
        [SerializeField] private InputField _chatInput;
        [SerializeField] private Text _chatResponse;

        public async void OnChat()
        {
            string text = _chatInput.text;
            if (string.IsNullOrWhiteSpace(text))
            {
                Debug.LogError("Chat text should not be null or whitespace!");
                return;
            }

            // Note: It seems GeminiModel.Gemini1_5Flash is not very good at JSON.
            GeminiChatResponse response = await GeminiManager.Instance.Request<GeminiChatResponse>(new GeminiChatRequest(GeminiModel.Gemini1_5Pro, true)
            {
                Contents = new GeminiContent[]
                {
                    GeminiContent.GetContent(text, GeminiRole.User),
                },
                SystemInstruction = GeminiContent.GetContent("You are a helpful math teacher who teacher their students mathematics in the most helpful way possible."),
                GenerationConfig = new GeminiGenerationConfiguration()
                {
                    ResponseMimeType = GeminiResponseType.Json,
                    ResponseSchema = new GeminiSchema()
                    {
                        Type = GeminiSchemaDataType.Array,
                        Description = "A list of mathematical expressions.",
                        Items = new GeminiSchema()
                        {
                            Type = GeminiSchemaDataType.Object,
                            Properties = new Dictionary<string, GeminiSchema>()
                            {
                                {
                                    "expression", new GeminiSchema()
                                    {
                                        Type = GeminiSchemaDataType.String,
                                    }
                                },
                                {
                                    "explanation", new GeminiSchema()
                                    {
                                        Type = GeminiSchemaDataType.String,
                                    }
                                },
                            },
                            Required = new string[] { "expression", "explanation", },
                        },
                    },
                }
            });

            _chatResponse.text = response.Parts[0].Text;
        }
    }
}

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Uralstech.UGemini.Models;
using Uralstech.UGemini.Models.Content;
using Uralstech.UGemini.Models.Generation.Chat;
using Uralstech.UGemini.Models.Generation.Schema;
using Uralstech.UGemini.Models.Generation.Tools;
using Uralstech.UGemini.Models.Generation.Tools.Declaration;

#pragma warning disable IDE0090 // Use 'new(...)'

namespace Uralstech.UGemini.Samples
{
    public class FunctionCallingChatManager : MonoBehaviour
    {
        private static readonly GeminiTool s_geminiFunctions = new GeminiTool()
        {
            FunctionDeclarations = new GeminiFunctionDeclaration[]
            {
                new GeminiFunctionDeclaration()
                {
                    Name = "printToConsole",
                    Description = "Print text to the user's console.",
                    Parameters = new GeminiSchema()
                    {
                        Type = GeminiSchemaDataType.Object,
                        Properties = new Dictionary<string, GeminiSchema>()
                        {
                            {
                                "text", new GeminiSchema()
                                {
                                    Type = GeminiSchemaDataType.String,
                                    Description = "The text to print. e.g. \"Hello, World!\"",
                                    Nullable = false,
                                }
                            },
                        },
                        Required = new string[] { "text" },
                    }
                },

                new GeminiFunctionDeclaration()
                {
                    Name = "changeTextColor",
                    Description = "Change the color of the text.",
                    Parameters = new GeminiSchema()
                    {
                        Type = GeminiSchemaDataType.Object,
                        Properties = new Dictionary<string, GeminiSchema>()
                        {
                            {
                                "color", new GeminiSchema()
                                {
                                    Type = GeminiSchemaDataType.String,
                                    Description = "The color to set. e.g. \"BLUE\"",
                                    Format = GeminiSchemaDataFormat.Enum,
                                    Enum = new string[]
                                    {
                                        "RED",
                                        "GREEN",
                                        "BLUE",
                                        "WHITE",
                                    },
                                    Nullable = false,
                                }
                            },
                        },
                        Required = new string[] { "color" },
                    }
                }
            },
        };

        [SerializeField] private int _maxFunctionCalls = 3;
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

            List<GeminiContent> contents = new()
            {
                GeminiContent.GetContent(text, GeminiRole.User),
            };

            GeminiChatResponse response;
            GeminiFunctionCall functionCall;
            int responseIterations = 0;

            do
            {
                response = await GeminiManager.Instance.Request<GeminiChatResponse>(new GeminiChatRequest(GeminiModel.Gemini1_5Flash, true)
                {
                    Contents = contents.ToArray(),
                    Tools = new GeminiTool[] { s_geminiFunctions },
                });

                contents.Add(response.Candidates[0].Content);

                _chatResponse.text = Array.Find(response.Parts, part => !string.IsNullOrEmpty(part.Text))?.Text;
                GeminiContentPart[] allFunctionCalls = Array.FindAll(response.Parts, part => part.FunctionCall != null);

                functionCall = null;
                for (int i = 0; i < allFunctionCalls.Length; i++)
                {
                    functionCall = allFunctionCalls[i].FunctionCall;
                    JObject functionResponse = null;

                    switch (functionCall.Name)
                    {
                        case "printToConsole":
                            Debug.Log(functionCall.Arguments["text"].ToObject<string>());
                            break;

                        case "changeTextColor":
                            if (!TryChangeTextColor(functionCall.Arguments["color"].ToObject<string>()))
                            {
                                functionResponse = new JObject()
                                {
                                    ["result"] = "Unknown color."
                                };
                            }

                            break;

                        default:
                            functionResponse = new JObject()
                            {
                                ["result"] = "Sorry, but that function does not exist."
                            };

                            break;
                    }

                    contents.Add(GeminiContent.GetContent(functionCall.GetResponse(functionResponse ?? new JObject()
                    {
                        ["result"] = "Completed executing function successfully."
                    })));
                }

                responseIterations++;
            } while (functionCall != null && responseIterations <= _maxFunctionCalls);
        }

        private bool TryChangeTextColor(string color)
        {
            switch (color)
            {
                case "RED":
                    _chatResponse.color = Color.red; break;

                case "GREEN":
                    _chatResponse.color = Color.green; break;

                case "BLUE":
                    _chatResponse.color = Color.blue; break;

                case "WHITE":
                    _chatResponse.color = Color.white; break;

                default:
                    return false;
            }

            Debug.Log("Changed text color!");
            return true;
        }
    }
}

#pragma warning restore IDE0090 // Use 'new(...)'
using UnityEngine;
using UnityEngine.UI;
using Uralstech.UGemini.Models;
using Uralstech.UGemini.TokenCounting;

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

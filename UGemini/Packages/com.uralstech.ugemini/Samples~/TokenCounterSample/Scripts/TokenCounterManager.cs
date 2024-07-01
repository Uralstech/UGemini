using UnityEngine;
using UnityEngine.UI;
using Uralstech.UGemini.TokenCounting;

namespace Uralstech.UGemini.Samples
{
    public class TokenCounterManager : MonoBehaviour
    {
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

            GeminiTokenCountResponse response = await GeminiManager.Instance.Compute<GeminiTokenCountRequest, GeminiTokenCountResponse>(new GeminiTokenCountRequest()
            {
                Contents = new GeminiContent[]
                {
                    GeminiContent.GetContent(text, GeminiRole.User),
                },
            }, GeminiManager.RequestEndPoint.CountTokens, GeminiManager.Gemini1_5Flash, true);
            
            _response.text = $"Tokens: {response.TotalTokens}";
        }
    }
}

using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Uralstech.Utils.Singleton;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Uralstech.GeminiAPI
{
    public class GeminiManager : Singleton<GeminiManager>
    {
        [SerializeField] private string _apiKey;

        public void SetApiKey(string apiKey)
        {
            _apiKey = apiKey;
        }

        public enum RequestType
        {
            Chat,
            CountTokens,
        }

        public async Task<TResponse> ModelRequest<TRequest, TResponse>(TRequest request, RequestType type, string model = "gemini-pro", bool useBeta = false)
        {
            string function = type switch {
                RequestType.Chat => "generateContent",
                RequestType.CountTokens => "countTokens",
                _ => throw new ArgumentException($"Unknown request type \"{type}\"!")
            };

            string apiVersion = useBeta ? "v1beta" : "v1";

            string data = JsonConvert.SerializeObject(request);
            using UnityWebRequest webRequest = UnityWebRequest.Post(
                $"https://generativelanguage.googleapis.com/{apiVersion}/models/{model}:{function}",
                data,
                "application/json; charset=utf-8"
            );

            webRequest.SetRequestHeader("X-goog-api-key", _apiKey);

            UnityWebRequestAsyncOperation operation = webRequest.SendWebRequest();
            while (!operation.isDone)
                await Task.Yield();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"Could not get Gemini \"{type}\" response: {webRequest.error} | {webRequest.downloadHandler.text}");
                return default;
            }

            Debug.Log(webRequest.downloadHandler.text);
            return JsonConvert.DeserializeObject<TResponse>(webRequest.downloadHandler.text);
        }
    }
}

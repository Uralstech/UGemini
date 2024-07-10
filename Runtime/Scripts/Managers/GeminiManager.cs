using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Uralstech.UGemini.Exceptions;
using Uralstech.UGemini.Utils.Singleton;
using Uralstech.UGemini.Utils.Web;

namespace Uralstech.UGemini
{
    /// <summary>
    /// The class for accessing the Gemini API!
    /// </summary>
    [AddComponentMenu("Uralstech/UGemini/Gemini API Manager")]
    public class GeminiManager : Singleton<GeminiManager>
    {
        private const string MultiPartFormDataSeperator = "xxxxxxxxxx";

        /// <summary>
        /// <a href="https://ai.google.dev/gemini-api/docs/models/gemini#gemini-1.0-pro-vision">
        /// Note: Gemini 1.0 Pro Vision is deprecated. Use 1.5 Flash or 1.5 Pro instead.
        /// <br/><br/>
        /// Gemini 1.0 Pro Vision is a performance-optimized multimodal model that can perform visual-related tasks.<br/>
        /// For example, 1.0 Pro Vision can generate image descriptions, identify objects present in images, provide<br/>
        /// information about places or objects present in images, and more.
        /// </a>
        /// <br/><br/>
        /// Supports image, video and text input.
        /// </summary>
        [Obsolete("Gemini 1.0 Pro Vision is deprecated. Use Use 1.5 Flash (Gemini1_5Flash) or 1.5 Pro (Gemini1_5Pro) instead.")]
        public const string Gemini1_0ProVision = "gemini-pro-vision";

        /// <summary>
        /// <a href="https://ai.google.dev/gemini-api/docs/models/gemini#gemini-1.0-pro">
        /// Gemini 1.0 Pro is an NLP model that handles tasks like multi-turn text and code chat, and code generation.
        /// </a>
        /// <br/><br/>
        /// Supports text input.
        /// </summary>
        public const string Gemini1_0Pro = "gemini-1.0-pro";

        /// <summary>
        /// <a href="https://ai.google.dev/gemini-api/docs/models/gemini#gemini-1.5-pro">
        /// Gemini 1.5 Pro is a mid-size multimodal model that is optimized for a wide-range of reasoning tasks.<br/>
        /// 1.5 Pro can process large amounts of data at once, including 2 hours of video, 19 hours of audio,<br/>
        /// codebases with 60,000 lines of code, or 2,000 pages of text.
        /// </a>
        /// <br/><br/>
        /// Supports audio, image, video and text input.
        /// </summary>
        public const string Gemini1_5Pro = "gemini-1.5-pro";

        /// <summary>
        /// <a href="https://ai.google.dev/gemini-api/docs/models/gemini#gemini-1.5-flash">
        /// Gemini 1.5 Flash is a fast and versatile multimodal model for scaling across diverse tasks.
        /// </a>
        /// <br/><br/>
        /// Supports audio, image, video and text input.
        /// </summary>
        public const string Gemini1_5Flash = "gemini-1.5-flash";

        [SerializeField, Tooltip("Your Gemini API key.")] private string _geminiApiKey;

        /// <summary>
        /// Sets the Gemini API key.
        /// </summary>
        /// <param name="apiKey">The new API key.</param>
        public void SetApiKey(string apiKey)
        {
            _geminiApiKey = apiKey;
        }

        /// <summary>
        /// Computes a request on the Gemini API.
        /// </summary>
        /// 
        /// <typeparam name="TResponse">
        /// The response type. For example, a request of type <see cref="Chat.GeminiChatRequest"/> corresponds
        /// to a response type of <see cref="Chat.GeminiChatResponse"/>, and a request of type <see cref="TokenCounting.GeminiTokenCountRequest"/>
        /// corresponds to a response of type <see cref="TokenCounting.GeminiTokenCountResponse"/>.
        /// </typeparam>
        /// 
        /// <param name="request">The request object.</param>
        /// <returns>The computed response.</returns>
        /// <exception cref="GeminiRequestException">Thrown when the API request fails.</exception>
        public async Task<TResponse> Request<TResponse>(IGeminiPostRequest request)
        {
            string utf8RequestData = request.GetUtf8EncodedData();
            string requestEndpoint = request.GetEndpointUri(null);

            using UnityWebRequest webRequest = UnityWebRequest.Post(requestEndpoint, utf8RequestData, request.ContentType);
            await ComputeRequest(webRequest);

            return JsonConvert.DeserializeObject<TResponse>(webRequest.downloadHandler.text);
        }

        /// <summary>
        /// Computes a request on the Gemini API.
        /// </summary>
        /// 
        /// <typeparam name="TResponse">
        /// The response type. For example, a request of type <see cref="Chat.GeminiChatRequest"/> corresponds
        /// to a response type of <see cref="Chat.GeminiChatResponse"/>, and a request of type <see cref="TokenCounting.GeminiTokenCountRequest"/>
        /// corresponds to a response of type <see cref="TokenCounting.GeminiTokenCountResponse"/>.
        /// </typeparam>
        /// 
        /// <param name="request">The request object.</param>
        /// <returns>The computed response.</returns>
        /// <exception cref="GeminiRequestException">Thrown when the API request fails.</exception>
        public async Task<TResponse> Request<TResponse>(IGeminiMultiPartPostRequest request)
        {
            string requestEndpoint = request.GetEndpointUri(null);
            string requestData = request.GetUtf8EncodedData(MultiPartFormDataSeperator);

            using UnityWebRequest webRequest = UnityWebRequest.Post(requestEndpoint, requestData, $"multipart/related; boundary={MultiPartFormDataSeperator}");
            webRequest.SetRequestHeader("X-Goog-Upload-Protocol", "multipart");
            
            await ComputeRequest(webRequest);

            return JsonConvert.DeserializeObject<TResponse>(webRequest.downloadHandler.text);
        }

        /// <summary>
        /// Computes a request on the Gemini API.
        /// </summary>
        /// 
        /// <typeparam name="TResponse">
        /// The response type. For example, a request of type <see cref="Chat.GeminiChatRequest"/> corresponds
        /// to a response type of <see cref="Chat.GeminiChatResponse"/>, and a request of type <see cref="TokenCounting.GeminiTokenCountRequest"/>
        /// corresponds to a response of type <see cref="TokenCounting.GeminiTokenCountResponse"/>.
        /// </typeparam>
        /// 
        /// <param name="request">The request object.</param>
        /// <exception cref="GeminiRequestException">Thrown when the API request fails.</exception>
        public async Task<TResponse> Request<TResponse>(IGeminiGetRequest request)
        {
            string requestEndpoint = request.GetEndpointUri(null);

            using UnityWebRequest webRequest = UnityWebRequest.Get(requestEndpoint);
            await ComputeRequest(webRequest);

            return JsonConvert.DeserializeObject<TResponse>(webRequest.downloadHandler.text);
        }

        /// <summary>
        /// Computes a request on the Gemini API.
        /// </summary>
        /// <param name="request">The request object.</param>
        /// <exception cref="GeminiRequestException">Thrown when the API request fails.</exception>
        public async Task Request(IGeminiDeleteRequest request)
        {
            string requestEndpoint = request.GetEndpointUri(null);
            using UnityWebRequest webRequest = UnityWebRequest.Delete(requestEndpoint);

            await ComputeRequest(webRequest);
        }

#if UTILITIES_ASYNC_1_0_0_OR_GREATER
        /// <summary>
        /// Computes a streaming request on the Gemini API.
        /// </summary>
        /// <remarks>
        /// Use callbacks in the request object to receive the streamed data.
        /// </remarks>
        /// 
        /// <typeparam name="TResponse">
        /// The response type. For example, a request of type <see cref="Chat.GeminiChatRequest"/> corresponds
        /// to a response type of <see cref="Chat.GeminiChatResponse"/>, and a request of type <see cref="TokenCounting.GeminiTokenCountRequest"/>
        /// corresponds to a response of type <see cref="TokenCounting.GeminiTokenCountResponse"/>.
        /// </typeparam>
        /// 
        /// <param name="request">The request object.</param>
        /// <exception cref="GeminiRequestException">Thrown when the API request fails.</exception>
        public async Task<TResponse> StreamRequest<TResponse>(IGeminiStreamablePostRequest<TResponse> request)
            where TResponse : IAppendableData<TResponse>
        {
            string utf8RequestData = request.GetUtf8EncodedData();
            string requestEndpoint = request.GetEndpointUri(new GeminiRequestMetadata()
            {
                IsStreaming = true,
            });

            using UnityWebRequest webRequest = UnityWebRequest.Post(requestEndpoint, utf8RequestData, request.ContentType);
            SetupWebRequest(webRequest);

            await webRequest.SendStreamingWebRequest(request.ProcessStreamedData);
            CheckWebRequest(webRequest);

            return request.StreamedResponse;
        }
#endif

        private async Task ComputeRequest(UnityWebRequest webRequest)
        {
            SetupWebRequest(webRequest);

            UnityWebRequestAsyncOperation operation = webRequest.SendWebRequest();
            while (!operation.isDone)
                await Task.Yield();

            CheckWebRequest(webRequest);
        }

        private void SetupWebRequest(UnityWebRequest webRequest)
        {
            webRequest.SetRequestHeader("X-goog-api-key", _geminiApiKey);
            webRequest.disposeUploadHandlerOnDispose = true;
            webRequest.disposeDownloadHandlerOnDispose = true;
        }

        private void CheckWebRequest(UnityWebRequest webRequest)
        {
            if (webRequest.result != UnityWebRequest.Result.Success)
                throw new GeminiRequestException(webRequest);

            Debug.Log("Gemini API computation succeeded.");
        }

        #region Obsolete
        /// <summary>
        /// The request endpoint.
        /// </summary>
        [Obsolete("It is recommended to use GeminiManager.Request instead of GeminiManager.Compute, as it is more generic and thus supports more request types.")]
        public enum RequestEndPoint
        {
            /// <summary>The chat endpoint.</summary>
            Chat,

            /// <summary>The token counting endpoint.</summary>
            CountTokens,
        }

        /// <summary>
        /// Computes a request in the Gemini API.
        /// </summary>
        /// 
        /// <typeparam name="TRequest">
        /// The request type (like <see cref="Chat.GeminiChatRequest">GeminiChatRequest</see>
        /// or <see cref="TokenCounting.GeminiTokenCountResponse">GeminiCountRequest</see>).
        /// <br/><br/>
        /// This should correspond with <typeparamref name="TResponse"/>, like:<br/>
        /// <see cref="Chat.GeminiChatRequest">GeminiChatRequest</see> with <see cref="Chat.GeminiChatResponse">GeminiChatResponse</see><br/>
        /// <see cref="TokenCounting.GeminiTokenCountRequest">GeminiCountRequest</see> with <see cref="TokenCounting.GeminiTokenCountResponse">GeminiCountResponse</see>
        /// </typeparam>
        /// 
        /// <typeparam name="TResponse">
        /// The response type (like <see cref="Chat.GeminiChatResponse">GeminiChatResponse</see>
        /// or <see cref="TokenCounting.GeminiTokenCountResponse">GeminiCountResponse</see>).
        /// <br/><br/>
        /// This should correspond with <typeparamref name="TRequest"/>, like:<br/>
        /// <see cref="Chat.GeminiChatRequest">GeminiChatRequest</see> with <see cref="Chat.GeminiChatResponse">GeminiChatResponse</see><br/>
        /// <see cref="TokenCounting.GeminiTokenCountRequest">GeminiCountRequest</see> with <see cref="TokenCounting.GeminiTokenCountResponse">GeminiCountResponse</see>
        /// </typeparam>
        /// 
        /// <param name="request">The request data.</param>
        /// <param name="endpoint">The request endpoint.</param>
        /// <param name="model">The model to use.</param>
        /// <param name="useBeta">Use the beta API?</param>
        /// <returns>The computed request.</returns>
        /// <exception cref="ArgumentException">Thrown if unexpected arguments are encountered.</exception>
        /// <exception cref="GeminiRequestException">Thrown when the API request fails.</exception>
        [Obsolete("It is recommended to use GeminiManager.Request instead of GeminiManager.Compute, as it is more generic and thus supports more request types.")]
        public async Task<TResponse> Compute<TRequest, TResponse>(TRequest request, RequestEndPoint endpoint, string model = Gemini1_5Flash, bool useBeta = false)
        {
            Debug.Log("Computing request on Gemini API.");
            string endpointFunction = endpoint switch
            {
                RequestEndPoint.Chat => "generateContent",
                RequestEndPoint.CountTokens => "countTokens",
                _ => throw new ArgumentException($"Unknown request endpoint \"{endpoint}\"!", nameof(endpoint))
            };

            string apiVersion = useBeta ? "v1beta" : "v1";

            string requestJson = JsonConvert.SerializeObject(request);
            using UnityWebRequest webRequest = UnityWebRequest.Post(
                $"https://generativelanguage.googleapis.com/{apiVersion}/models/{model}:{endpointFunction}",
                requestJson, "application/json; charset=utf-8"
            );

            webRequest.SetRequestHeader("X-goog-api-key", _geminiApiKey);

            UnityWebRequestAsyncOperation operation = webRequest.SendWebRequest();
            while (!operation.isDone)
                await Task.Yield();

            if (webRequest.result != UnityWebRequest.Result.Success)
                throw new GeminiRequestException(endpoint, webRequest, apiVersion);

            Debug.Log("Gemini API computation succeeded.");
            return JsonConvert.DeserializeObject<TResponse>(webRequest.downloadHandler.text);
        }
        #endregion
    }
}
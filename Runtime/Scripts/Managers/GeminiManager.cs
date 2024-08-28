using Newtonsoft.Json;
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
        /// Computes a POST request on the Gemini API.
        /// </summary>
        /// 
        /// <typeparam name="TResponse">
        /// The response type. For example, a request of type <see cref="Models.Generation.Chat.GeminiChatRequest"/> corresponds
        /// to a response type of <see cref="Models.Generation.Chat.GeminiChatResponse"/>, and a request of type <see cref="Models.CountTokens.GeminiTokenCountRequest"/>
        /// corresponds to a response of type <see cref="Models.CountTokens.GeminiTokenCountResponse"/>.
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
        /// Computes a multi-part POST request on the Gemini API.
        /// </summary>
        /// 
        /// <typeparam name="TResponse">
        /// The response type. For example, a request of type <see cref="Models.Generation.Chat.GeminiChatRequest"/> corresponds
        /// to a response type of <see cref="Models.Generation.Chat.GeminiChatResponse"/>, and a request of type <see cref="Models.CountTokens.GeminiTokenCountRequest"/>
        /// corresponds to a response of type <see cref="Models.CountTokens.GeminiTokenCountResponse"/>.
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
        /// Computes a GET request on the Gemini API.
        /// </summary>
        /// 
        /// <typeparam name="TResponse">
        /// The response type. For example, a request of type <see cref="Models.Generation.Chat.GeminiChatRequest"/> corresponds
        /// to a response type of <see cref="Models.Generation.Chat.GeminiChatResponse"/>, and a request of type <see cref="Models.CountTokens.GeminiTokenCountRequest"/>
        /// corresponds to a response of type <see cref="Models.CountTokens.GeminiTokenCountResponse"/>.
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
        /// Computes a DELETE request on the Gemini API.
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
        /// Computes a streaming POST request on the Gemini API.
        /// </summary>
        /// <remarks>
        /// Use callbacks in the request object to receive the streamed data.
        /// </remarks>
        /// 
        /// <typeparam name="TResponse">
        /// The response type. For example, a request of type <see cref="Models.Generation.Chat.GeminiChatRequest"/> corresponds
        /// to a response type of <see cref="Models.Generation.Chat.GeminiChatResponse"/>, and a request of type <see cref="Models.CountTokens.GeminiTokenCountRequest"/>
        /// corresponds to a response of type <see cref="Models.CountTokens.GeminiTokenCountResponse"/>.
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

        /// <summary>
        /// Sets up, sends and verifies a <see cref="UnityWebRequest"/>.
        /// </summary>
        /// <param name="webRequest">The <see cref="UnityWebRequest"/> to compute.</param>
        private async Task ComputeRequest(UnityWebRequest webRequest)
        {
            SetupWebRequest(webRequest);

            UnityWebRequestAsyncOperation operation = webRequest.SendWebRequest();
            while (!operation.isDone)
                await Task.Yield();

            CheckWebRequest(webRequest);
        }

        /// <summary>
        /// Sets up the <see cref="UnityWebRequest"/> with API keys and disposal settings.
        /// </summary>
        /// <param name="webRequest">The request to set up.</param>
        private void SetupWebRequest(UnityWebRequest webRequest)
        {
            webRequest.SetRequestHeader("X-goog-api-key", _geminiApiKey);
            webRequest.disposeUploadHandlerOnDispose = true;
            webRequest.disposeDownloadHandlerOnDispose = true;
        }

        /// <summary>
        /// Checks the given <see cref="UnityWebRequest"/> for errors.
        /// </summary>
        /// <param name="webRequest">The request to check.</param>
        /// <exception cref="GeminiRequestException">Thrown if the request was not successful</exception>
        private void CheckWebRequest(UnityWebRequest webRequest)
        {
            if (webRequest.result != UnityWebRequest.Result.Success)
                throw new GeminiRequestException(webRequest);

            Debug.Log("Gemini API computation succeeded.");
        }
    }
}

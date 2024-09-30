using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Uralstech.UGemini.Exceptions;
using Uralstech.UGemini.Utils.Web;
using Uralstech.Utils.Singleton;

namespace Uralstech.UGemini
{
    /// <summary>
    /// The class for accessing the Gemini API!
    /// </summary>
    [AddComponentMenu("Uralstech/UGemini/Gemini API Manager")]
    public class GeminiManager : Singleton<GeminiManager>
    {
        /// <summary>
        /// The base URI to the Generative Language service.
        /// </summary>
        public const string BaseServiceUri = "https://generativelanguage.googleapis.com";

        /// <summary>
        /// The production v1 API URI to the Generative Language service.
        /// </summary>
        public const string ProductionApiUri = "https://generativelanguage.googleapis.com/v1";

        /// <summary>
        /// The v1 beta API URI to the Generative Language service.
        /// </summary>
        public const string BetaApiUri = "https://generativelanguage.googleapis.com/v1beta";

        /// <summary>
        /// Seperator for Multi-Part Form Data.
        /// </summary>
        private const string MultiPartFormDataSeperator = "xxxxxxxxxx";

        /// <summary>
        /// An empty JSON object.
        /// </summary>
        private const string EmptyJsonObject = "{}";

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
        /// <exception cref="GeminiRequestException">Thrown if the API request fails.</exception>
        /// <exception cref="GeminiResponseParsingException">Thrown if the response could not be parsed.</exception>
        public async Task<TResponse> Request<TResponse>(IGeminiPostRequest request)
        {
            string utf8RequestData = request.GetUtf8EncodedData();
            string requestEndpoint = request.GetEndpointUri(null);

            using UnityWebRequest webRequest = UnityWebRequest.Post(requestEndpoint, utf8RequestData, request.ContentType);
            await ComputeRequest(request, webRequest);

            return ConfirmResponse<TResponse>(webRequest);
        }

        /// <summary>
        /// Computes a POST request on the Gemini API.
        /// </summary>
        /// <param name="request">The request object.</param>
        /// <exception cref="GeminiRequestException">Thrown if the API request fails.</exception>
        /// <exception cref="GeminiResponseParsingException">Thrown if the response was not empty.</exception>
        public async Task Request(IGeminiPostRequest request)
        {
            string utf8RequestData = request.GetUtf8EncodedData();
            string requestEndpoint = request.GetEndpointUri(null);

            using UnityWebRequest webRequest = UnityWebRequest.Post(requestEndpoint, utf8RequestData, request.ContentType);
            await ComputeRequest(request, webRequest);

            ConfirmResponse(webRequest);
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
        /// <exception cref="GeminiRequestException">Thrown if the API request fails.</exception>
        /// <exception cref="GeminiResponseParsingException">Thrown if the response could not be parsed.</exception>
        public async Task<TResponse> Request<TResponse>(IGeminiMultiPartPostRequest request)
        {
            string requestEndpoint = request.GetEndpointUri(null);
            string requestData = request.GetUtf8EncodedData(MultiPartFormDataSeperator);

            using UnityWebRequest webRequest = UnityWebRequest.Post(requestEndpoint, requestData, $"multipart/related; boundary={MultiPartFormDataSeperator}");
            webRequest.SetRequestHeader("X-Goog-Upload-Protocol", "multipart");

            await ComputeRequest(request, webRequest);
            return ConfirmResponse<TResponse>(webRequest);
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
        /// <returns>The computed response.</returns>
        /// <exception cref="GeminiRequestException">Thrown if the API request fails.</exception>
        /// <exception cref="GeminiResponseParsingException">Thrown if the response could not be parsed.</exception>
        public async Task<TResponse> Request<TResponse>(IGeminiGetRequest request)
        {
            string requestEndpoint = request.GetEndpointUri(null);

            using UnityWebRequest webRequest = UnityWebRequest.Get(requestEndpoint);
            await ComputeRequest(request, webRequest);

            return ConfirmResponse<TResponse>(webRequest);
        }

        /// <summary>
        /// Computes a DELETE request on the Gemini API.
        /// </summary>
        /// <param name="request">The request object.</param>
        /// <exception cref="GeminiRequestException">Thrown if the API request fails.</exception>
        /// <exception cref="GeminiResponseParsingException">Thrown if the response was not empty.</exception>
        public async Task Request(IGeminiDeleteRequest request)
        {
            string requestEndpoint = request.GetEndpointUri(null);
            using UnityWebRequest webRequest = UnityWebRequest.Delete(requestEndpoint);

            await ComputeRequest(request, webRequest);
            ConfirmResponse(webRequest);
        }

        /// <summary>
        /// Computes a PATCH request on the Gemini API.
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
        /// <exception cref="GeminiRequestException">Thrown if the API request fails.</exception>
        /// <exception cref="GeminiResponseParsingException">Thrown if the response could not be parsed.</exception>
        public async Task<TResponse> Request<TResponse>(IGeminiPatchRequest request)
        {
            string utf8RequestData = request.GetUtf8EncodedData();
            string requestEndpoint = request.GetEndpointUri(null);

            using UnityWebRequest webRequest = new(
                requestEndpoint, "PATCH",
                new DownloadHandlerBuffer(),
                new UploadHandlerRaw(Encoding.UTF8.GetBytes(utf8RequestData))
                {
                    contentType = request.ContentType
                }
            );

            webRequest.SetRequestHeader("Content-Type", request.ContentType);
            await ComputeRequest(request, webRequest);

            return ConfirmResponse<TResponse>(webRequest);
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
        /// <returns>The computed response.</returns>
        /// <exception cref="GeminiRequestException">Thrown if the API request fails.</exception>
        public async Task<TResponse> StreamRequest<TResponse>(IGeminiStreamablePostRequest<TResponse> request)
            where TResponse : IAppendableData<TResponse>
        {
            string utf8RequestData = request.GetUtf8EncodedData();
            string requestEndpoint = request.GetEndpointUri(new GeminiRequestMetadata()
            {
                IsStreaming = true,
            });

            using UnityWebRequest webRequest = UnityWebRequest.Post(requestEndpoint, utf8RequestData, request.ContentType);
            SetupWebRequest(request, webRequest);

            await webRequest.SendStreamingWebRequest(request.ProcessStreamedData);
            CheckWebRequest(webRequest);

            return request.StreamedResponse;
        }
#endif

        /// <summary>
        /// Sets up, sends and verifies a <see cref="UnityWebRequest"/>.
        /// </summary>
        /// <param name="request">The request data.</param>
        /// <param name="webRequest">The <see cref="UnityWebRequest"/> to compute.</param>
        private async Task ComputeRequest(IGeminiRequest request, UnityWebRequest webRequest)
        {
            SetupWebRequest(request, webRequest);

            UnityWebRequestAsyncOperation operation = webRequest.SendWebRequest();
            while (!operation.isDone)
                await Task.Yield();

            CheckWebRequest(webRequest);
        }

        /// <summary>
        /// Sets up the <see cref="UnityWebRequest"/> with API keys and disposal settings.
        /// </summary>
        /// <param name="request">The request data.</param>
        /// <param name="webRequest">The request to set up.</param>
        /// <exception cref="GeminiOAuthException">Thrown if the request could not be authenticated.</exception>
        private void SetupWebRequest(IGeminiRequest request, UnityWebRequest webRequest)
        {
            switch (request.AuthMethod)
            {
                case GeminiAuthMethod.APIKey:
                    webRequest.SetRequestHeader("X-goog-api-key", _geminiApiKey); break;

                case GeminiAuthMethod.OAuthAccessToken:
                    if (string.IsNullOrWhiteSpace(request.OAuthAccessToken))
                        throw new GeminiOAuthException(webRequest, $"Authentication method was set to {request.AuthMethod} but the provided access token was empty!");

                    webRequest.SetRequestHeader("Authorization", $"Bearer {request.OAuthAccessToken}"); break;

                default:
                    throw new GeminiOAuthException(webRequest, $"Unknown authentication method {request.AuthMethod}.");
            }


            webRequest.disposeUploadHandlerOnDispose = true;
            webRequest.disposeDownloadHandlerOnDispose = true;
        }

        /// <summary>
        /// Checks the given <see cref="UnityWebRequest"/> for errors.
        /// </summary>
        /// <param name="webRequest">The request to check.</param>
        /// <exception cref="GeminiRequestException">Thrown if the request was not successful.</exception>
        private void CheckWebRequest(UnityWebRequest webRequest)
        {
            if (webRequest.result != UnityWebRequest.Result.Success)
                throw new GeminiRequestException(webRequest);

            Debug.Log("Gemini API computation succeeded.");
        }

        /// <summary>
        /// Checks if the downloaded response was correct.
        /// </summary>
        /// <typeparam name="TResponse">The expected response type.</typeparam>
        /// <param name="request">The web request.</param>
        /// <exception cref="GeminiResponseParsingException">Thrown if the response could not be parsed.</exception>
        private TResponse ConfirmResponse<TResponse>(UnityWebRequest request)
        {
            try
            {
                return JsonConvert.DeserializeObject<TResponse>(request.downloadHandler?.text);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to confirm successful API response:\n{e}");
                throw new GeminiResponseParsingException(request, e);
            }
        }

        /// <summary>
        /// Checks if the downloaded response was empty, as to be expected of some endpoints.
        /// </summary>
        /// <param name="request">The web request.</param>
        /// <exception cref="GeminiResponseParsingException">Thrown if the response was not empty.</exception>
        private void ConfirmResponse(UnityWebRequest request)
        {
            if (!string.IsNullOrEmpty(request.downloadHandler?.text) && request.downloadHandler.text.Trim() != EmptyJsonObject)
            {
                Debug.LogError($"Failed to confirm successful API response:\n{request.downloadHandler?.text}");
                throw new GeminiResponseParsingException(request);
            }
        }
    }
}

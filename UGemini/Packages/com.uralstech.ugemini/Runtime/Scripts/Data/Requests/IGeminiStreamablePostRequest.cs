using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Uralstech.UGemini
{
    /// <summary>
    /// All streamed Gemini API POST requests must inherit from this interface.
    /// </summary>
    /// <typeparam name="TResponse">The streamed response type.</typeparam>
    public interface IGeminiStreamablePostRequest<TResponse> : IGeminiPostRequest
        where TResponse : IAppendableData<TResponse>
    {
        /// <summary>
        /// The response being streamed.
        /// </summary>
        public TResponse StreamedResponse { get; }

        /// <summary>
        /// Callback to process Server Sent Events (SSEs).
        /// </summary>
        /// <param name="allEvents">All previously sent SSEs.</param>
        /// <param name="lastEvent">The latest SSE.</param>
        public Task ProcessStreamedData(List<JToken> allEvents, JToken lastEvent);
    }
}

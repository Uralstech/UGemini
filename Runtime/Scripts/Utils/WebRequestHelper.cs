// The below code is inspired by code from RageAgainstThePixel's (https://github.com/RageAgainstThePixel/)
// Utilities.Rest (https://github.com/RageAgainstThePixel/com.utilities.rest/), which is licensed under
// the MIT license, which can be found here: https://github.com/RageAgainstThePixel/com.utilities.rest/blob/4b0cad9bdf46725ff44970c32f0ebb235aa2390e/LICENSE.md

using System.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

#if UTILITIES_ASYNC_1_0_0_OR_GREATER
using Utilities.Async;
#endif

namespace Uralstech.UGemini.Utils.Web
{
    /// <summary>
    /// Extensions for the <see cref="UnityWebRequest"/> type.
    /// </summary>
    public static class WebRequestHelper
    {
#if UTILITIES_ASYNC_1_0_0_OR_GREATER
        /// <summary>
        /// Sends a streaming web request.
        /// </summary>
        /// <param name="webRequest">The request to send.</param>
        /// <param name="serverSentEventHandler">
        /// The callback to handle Server Sent Events (SSEs).<br/>
        /// Parameters:<br/>
        ///     - List&lt;<see cref="JToken"/>&gt; : All SSEs, excluding the latest one.<br/>
        ///     - <see cref="JToken"/> : The latest SSE.<br/>
        /// Return type: <see cref="Task"/>
        /// </param>
        public static async Task SendStreamingWebRequest(this UnityWebRequest webRequest, Func<List<JToken>, JToken, Task> serverSentEventHandler)
        {
            await Awaiters.UnityMainThread;
            List<JToken> allServerSentEvents = new();

#pragma warning disable CS4014 // Running in background thread.
            Task.Run(CheckServerEvents);
#pragma warning restore CS4014

            UnityWebRequestAsyncOperation operation = webRequest.SendWebRequest();
            while (!operation.isDone)
                await Task.Yield();

            await SendServerEventCallback(true).ConfigureAwait(true);

            async void CheckServerEvents()
            {
                try
                {
                    await Awaiters.UnityMainThread;

                    while (!webRequest.isDone)
                    {
                        await SendServerEventCallback(false).ConfigureAwait(true);
                        await Awaiters.UnityMainThread;
                    }
                }
                catch (Exception) { }
            }

            async Task SendServerEventCallback(bool isEnd)
            {
                string allEventMessages = webRequest.downloadHandler?.text;
                if (string.IsNullOrWhiteSpace(allEventMessages))
                    return;

                if (allEventMessages[^1] != ']')
                    allEventMessages += ']';

                JArray data = JArray.Parse(allEventMessages);
                int stride = isEnd ? 0 : 1;

                for (int i = allServerSentEvents.Count; i < data.Count - stride; i++)
                {
                    JToken element = data[i];

                    try
                    {
                        await serverSentEventHandler.Invoke(allServerSentEvents, element).ConfigureAwait(true);
                    }
                    catch (Exception exception)
                    {
                        Debug.LogError($"Failed to handle server sent event: {exception}");
                    }

                    allServerSentEvents.Add(element);
                }
            }
        }
#endif
    }
}

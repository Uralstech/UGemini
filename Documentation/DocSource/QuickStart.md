# Quick Start

Please note that the code provided in this page is *purely* for learning purposes and is far from perfect. Remember to null-check all responses!

## Breaking Changes Notice

If you've just updated UGemini, it is recommended to check out the [*releases page*](https://github.com/Uralstech/UGemini/releases) for information on breaking changes for each update.

## Setup

Add an instance of `Uralstech.UGemini.GeminiManager` to your scene, and set it up with your Gemini API key. You can get your API key from [*here*](https://makersuite.google.com/app/apikey).

## GeminiManager

There are only three methods in `GeminiManager`:

| Method                | What it does                                      |
| -------------         | -------------                                     |
| `SetApiKey`           | Sets the Gemini API key through code              |
| `Request`             | Computes a request on the Gemini API              |
| `StreamRequest`\*     | Computes a streaming request on the Gemini API    |

\*Requires [*Utilities.Async*](https://openupm.com/packages/com.utilities.async/).

All computations on the Gemini API are done through `GeminiManager.Request`, `GeminiManager.StreamRequest` and their variants.

In this page, the fields, properties and methods of each type will not be explained. Every type has been fully documented in code, so
please check the code docstrings or reference documentation to learn more about each type.

## Beta API

`GeminiManager` supports both the `v1` and `v1beta` Gemini API versions. As a lot of features are still unsupported in the main `v1` API, you may
need to use the Beta API. You can set the `useBetaApi` boolean parameter in the request's constructor to do so.

## Models

`Uralstech.UGemini.Models.GeminiModel` has multiple static model IDs:

- [`Gemini1_5Flash`](https://ai.google.dev/gemini-api/docs/models/gemini#gemini-1.5-flash)
- [`Gemini1_5Pro`](https://ai.google.dev/gemini-api/docs/models/gemini#gemini-1.5-pro)
- [`Gemini1_0Pro`](https://ai.google.dev/gemini-api/docs/models/gemini#gemini-1.0-pro)
- And so on...

You can provide these to the `model` parameter in the constructors for model-related requests.
UGemini can also implicitly convert `string` model IDs to `GeminiModelId` objects.

## QuickStart: Multi-turn Chat Request

This is a simple script that maintains the user's chat history with Gemini.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.Models;
using Uralstech.UGemini.Models.Content;
using Uralstech.UGemini.Models.Generation.Chat;

private List<GeminiContent> _chatHistory = new();

private async Task<string> OnChat(string text)
{
    _chatHistory.Add(GeminiContent.GetContent(text, GeminiRole.User));
    GeminiChatResponse response = await GeminiManager.Instance.Request<GeminiChatResponse>(
        new GeminiChatRequest(GeminiModel.Gemini1_5Flash)
        {
            Contents = _chatHistory.ToArray(),
        }
    );
    
    _chatHistory.Add(response.Candidates[0].Content);
    return response.Parts[0].Text;
}
```

Here, we simply have a list of `GeminiContent` objects, which tracks the messages of the conversation.
Every time `OnChat` is called, the user's request and the model's reply are added the the list.

## What Next?

You can check out more [`GeminiChatRequest` Features](GeminiChatRequestFeatures.md) like Streaming Requests, Function Calling, Code Execution and more.
You can also read the documentation for [all Gemini API endpoints that UGemini supports](AllEndpoints.md) to learn more about features like File Uploads,
Content Caching and Fine Tuning.

## Samples

For full-fledged examples of the features of this package, check out the samples included in the package:

### Mult-turn Chat

A sample scene showing a multi-turn chat system. [***GitHub Source***](https://github.com/Uralstech/UGemini/tree/master/UGemini/Packages/com.uralstech.ugemini/Samples~/SimpleMultiTurnChatSample)

### Function Calling

A sample scene showing a function calling system. [***GitHub Source***](https://github.com/Uralstech/UGemini/tree/master/UGemini/Packages/com.uralstech.ugemini/Samples~/FunctionCallingSample)

### Streaming Generated Content

A sample showing a system which streams Gemini's responses, including function calls. [***GitHub Source***](https://github.com/Uralstech/UGemini/tree/master/UGemini/Packages/com.uralstech.ugemini/Samples~/StreamedFunctionCallingSample)

### Question Answering

A sample scene with a system where Gemini answers questions based only on the given context. [***GitHub Source***](https://github.com/Uralstech/UGemini/tree/master/UGemini/Packages/com.uralstech.ugemini/Samples~/QuestionAnsweringSample)

### Prompting with File API

A sample scene with a system to create, delete, retrieve, list and prompt Gemini with files stored in the File/Media API endpoints. [***GitHub Source***](https://github.com/Uralstech/UGemini/tree/master/UGemini/Packages/com.uralstech.ugemini/Samples~/FileAPISample)

### JSON Response

A sample scene showing a system where Gemini responds in a specified JSON format. [***GitHub Source***](https://github.com/Uralstech/UGemini/tree/master/UGemini/Packages/com.uralstech.ugemini/Samples~/JSONResponseSample)

### List and Get Model Metadata

A sample scene with a system to list, get and chat with models using the models.get and models.list endpoints. [***GitHub Source***](https://github.com/Uralstech/UGemini/tree/master/UGemini/Packages/com.uralstech.ugemini/Samples~/ModelMetadataRetrievalSample)

### Token Counting

A sample scene showing a token counting system using the `countTokens` endpoint. [***GitHub Source***](https://github.com/Uralstech/UGemini/tree/master/UGemini/Packages/com.uralstech.ugemini/Samples~/TokenCounterSample)
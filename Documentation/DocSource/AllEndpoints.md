
# All Supported Endpoints

## CachedContents (Beta API)

> Context caching allows you to save and reuse precomputed input tokens that you wish to use repeatedly, for example when asking different questions about the same media file.

### Create

> Creates CachedContent resource.

```csharp
private async Task<GeminiCachedContent> RunCreateCachedContentRequest()
{
    // Content must be at least 32,768 tokens.
    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < 1800; i++)
        sb.Append("(*)#$*OIJIR$U(IJT^(U$*I%O$#@");


    return await GeminiManager.Instance.Request<GeminiCachedContent>(new GeminiCachedContentCreateRequest(new GeminiCachedContentCreationData
    {
        Contents = new[]
        {
            GeminiContent.GetContent(sb.ToString(), GeminiRole.User),
        },
        ExpireTime = DateTime.UtcNow.AddDays(1),
        Model = "Gemini-1.5-flash-001", // Make sure the model you use supports caching!
    }));
}
```

See [GeminiCachedContent](~/api/Uralstech.UGemini.Models.Caching.GeminiCachedContent.yml) and [GeminiCachedContentCreateRequest](~/api/Uralstech.UGemini.Models.Caching.GeminiCachedContentCreateRequest.yml) for more details.

### Delete

> Deletes CachedContent resource.

```csharp
private async Task RunDeleteCachedContentRequest(GeminiCachedContent content)
{
    Debug.Log("Deleting cached content...");
    await GeminiManager.Instance.Request(new GeminiCachedContentDeleteRequest(content.Name));
    Debug.Log("Content deleted.");
}
```

See [GeminiCachedContentDeleteRequest](~/api/Uralstech.UGemini.Models.Caching.GeminiCachedContentDeleteRequest.yml) for more details.

### Get

> Reads CachedContent resource.

```csharp
private async Task<GeminiCachedContent> RunGetCachedContentRequest(string contentName)
{
    return await GeminiManager.Instance.Request<GeminiCachedContent>(new GeminiCachedContentGetRequest(contentName));
}
```

See [GeminiCachedContent](~/api/Uralstech.UGemini.Models.Caching.GeminiCachedContent.yml) and [GeminiCachedContentGetRequest](~/api/Uralstech.UGemini.Models.Caching.GeminiCachedContentGetRequest.yml) for more details.

### List

> Lists CachedContents.

```csharp
private async Task<GeminiCachedContent[]> RunListCachedContentRequest()
{
    GeminiCachedContentListResponse response = await GeminiManager.Instance.Request<GeminiCachedContentListResponse>(new GeminiCachedContentListRequest());
    return response.CachedContents;
}
```

See [GeminiCachedContentListResponse](~/api/Uralstech.UGemini.Models.Caching.GeminiCachedContentListResponse.yml) and [GeminiCachedContentListRequest](~/api/Uralstech.UGemini.Models.Caching.GeminiCachedContentListRequest.yml) for more details.

### Patch

> Updates CachedContent resource (only expiration is updatable).

```csharp
private async Task<GeminiCachedContent> RunPatchCachedContentRequest(string contentName)
{
    return await GeminiManager.Instance.Request<GeminiCachedContent>(new GeminiCachedContentPatchRequest(new GeminiCachedContentPatchData
    {
        ExpireTime = DateTime.UtcNow.AddYears(1),
    }, contentName));
}
```

See [GeminiCachedContent](~/api/Uralstech.UGemini.Models.Caching.GeminiCachedContent.yml) and [GeminiCachedContentPatchRequest](~/api/Uralstech.UGemini.Models.Caching.GeminiCachedContentPatchRequest.yml) for more details.

## Models

> The Models endpoint contains methods that allow you to access and inference Gemini models.

### Get

> Gets information about a specific Model such as its version number, token limits, parameters and other metadata.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.Models;

private async Task<GeminiModel> RunGetModelRequest(string modelId)
{
    return await GeminiManager.Instance.Request<GeminiModel>(new GeminiModelGetRequest(modelId));
}
```

See [GeminiModel](~/api/Uralstech.UGemini.Models.GeminiModel.yml) and [GeminiModelGetRequest](~/api/Uralstech.UGemini.Models.GeminiModelGetRequest.yml) for more details.

Newer models will not be recognized by the request if you're not using the Beta API.

### List

> Lists the Models available through the Gemini API.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.Models;

private async Task<GeminiModel[]> RunListModelsRequest(int maxModels = 50, string pageToken = null)
{
    GeminiModelListResponse response = await GeminiManager.Instance.Request<GeminiModelListResponse>(new GeminiModelListRequest()
    {
        MaxResponseModels = maxModels,
        PageToken = string.IsNullOrWhiteSpace(pageToken) ? string.Empty : pageToken,
    });

    return response?.Models;
}
```

See [GeminiModelListResponse](~/api/Uralstech.UGemini.Models.GeminiModelListResponse.yml) and [GeminiModelListRequest](~/api/Uralstech.UGemini.Models.GeminiModelListRequest.yml) for more details.

Newer models will not be recognized by the request if you're not using the Beta API.

### EmbedContent

> Generates a text embedding vector from the input Content using the specified Gemini Embedding model.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.Models;
using Uralstech.UGemini.Models.Content;
using Uralstech.UGemini.Models.Embedding;

private async void RunEmbedContentRequest()
{
    Debug.Log("Running embedding request.");

    GeminiEmbedContentResponse response = await GeminiManager.Instance.Request<GeminiEmbedContentResponse>(
        new GeminiEmbedContentRequest(GeminiModel.TextEmbedding004)
        {
            Content = GeminiContent.GetContent("Hello! How are you?"),
        }
    );

    Debug.Log($"Embedding values: {string.Join(", ", response.Embedding.Values)}");
}
```

See [GeminiEmbedContentResponse](~/api/Uralstech.UGemini.Models.Embedding.GeminiEmbedContentResponse.yml) and [GeminiEmbedContentRequest](~/api/Uralstech.UGemini.Models.Embedding.GeminiEmbedContentRequest.yml) for more details.

### BatchEmbedContents

> Generates multiple embedding vectors from the input Content which consists of a batch of strings represented as EmbedContentRequest objects.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.Models;
using Uralstech.UGemini.Models.Content;
using Uralstech.UGemini.Models.Embedding;

private async void RunBatchEmbedContentRequest()
{
    Debug.Log("Running batch embedding request.");

    // Make sure the model used for the batch request is the same for all included requests.
    GeminiBatchEmbedContentResponse response = await GeminiManager.Instance.Request<GeminiBatchEmbedContentResponse>(
        new GeminiBatchEmbedContentRequest(GeminiModel.TextEmbedding004)
        {
            Requests = new GeminiEmbedContentRequest[]
            {
                new GeminiEmbedContentRequest(GeminiModel.TextEmbedding004)
                {
                    Content = GeminiContent.GetContent("Hello! How are you?"),
                },
                new GeminiEmbedContentRequest(GeminiModel.TextEmbedding004)
                {
                    Content = GeminiContent.GetContent("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."),
                }
            }
        }
    );

    foreach (GeminiContentEmbedding embedding in response.Embeddings)
        Debug.Log($"Embedding values: {string.Join(", ", embedding.Values)}");
}
```

See [GeminiBatchEmbedContentResponse](~/api/Uralstech.UGemini.Models.Embedding.GeminiBatchEmbedContentResponse.yml) and [GeminiBatchEmbedContentRequest](~/api/Uralstech.UGemini.Models.Embedding.GeminiBatchEmbedContentRequest.yml) for more details.

### GenerateContent

> Generates a model response given an input GenerateContentRequest.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.Models;
using Uralstech.UGemini.Models.Content;
using Uralstech.UGemini.Models.Generation.Chat;

private async void RunChatRequest()
{
    Debug.Log("Running chat request.");

    GeminiChatResponse response = await GeminiManager.Instance.Request<GeminiChatResponse>(
        new GeminiChatRequest(GeminiModel.Gemini1_5Flash)
        {
            Contents = new GeminiContent[]
            {
                GeminiContent.GetContent("What's up?")
            },
        }
    );
    
    Debug.Log($"Gemini's response: {response.Parts[^1].Text}");
}
```

See [GeminiChatResponse](~/api/Uralstech.UGemini.Models.Generation.Chat.GeminiChatResponse.yml) and [GeminiChatRequest](~/api/Uralstech.UGemini.Models.Generation.Chat.GeminiChatRequest.yml) for more details.

### StreamGenerateContent

> Generates a streamed response from the model given an input GenerateContentRequest.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.Models;
using Uralstech.UGemini.Models.Content;
using Uralstech.UGemini.Models.Generation.Chat;

private async void RunStreamingChatRequest()
{
    Debug.Log("Running streamed chat request.");

    GeminiChatResponse response = await GeminiManager.Instance.StreamRequest(
        new GeminiChatRequest(GeminiModel.Gemini1_5Flash)
        {
            Contents = new GeminiContent[]
            {
                GeminiContent.GetContent("What's up? Tell me a story about airplanes.")
            },
            OnPartialResponseReceived = partialResponse =>
            {
                if (partialResponse.Candidates == null || partialResponse.Candidates.Length < 0)
                    return Task.CompletedTask;

                Debug.Log($"Gemini's partial response: {partialResponse.Parts[^1].Text}");
                return Task.CompletedTask;
            }
        }
    );

    Debug.Log($"Gemini's final response: {response.Parts[^1].Text}");
}
```

See [GeminiChatResponse](~/api/Uralstech.UGemini.Models.Generation.Chat.GeminiChatResponse.yml) and [GeminiChatRequest](~/api/Uralstech.UGemini.Models.Generation.Chat.GeminiChatRequest.yml) for more details.

### GenerateAnswer	(Beta API)

> Generates a grounded answer from the model given an input GenerateAnswerRequest.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.Models;
using Uralstech.UGemini.Models.Content;
using Uralstech.UGemini.Models.Content.Attribution;
using Uralstech.UGemini.Models.Generation.QuestionAnswering;
using Uralstech.UGemini.Models.Generation.QuestionAnswering.Grounding;

private async void RunQuestionAnsweringRequest()
{
    Debug.Log("Running Q/A request.");

    GeminiAnswerResponse response = await GeminiManager.Instance.Request<GeminiAnswerResponse>(
        new GeminiAnswerRequest(GeminiModel.Aqa)
        {
            Contents = new GeminiContent[]
            {
                GeminiContent.GetContent("What is ezr²?")
            },

            InlinePassages = new GeminiGroundingPassages()
            {
                Passages = new GeminiGroundingPassage[]
                {
                    new GeminiGroundingPassage()
                    {
                        Id = "ezrSquaredContext",
                        Content = GeminiContent.GetContent(
                            "ezr² is an easy to learn and practical interpreted programming language for beginners and experts alike made in C#." +
                            "The latest version of ezr² RE has been released! ezr² RE, or REwrite, is the project's initiative to rewrite ezr². " +
                            "The latest working version of ezr² RE has many more features than the latest version of ezr²! But, it is still in " +
                            "development, has some essential features missing. Like the include expression, or any built-in object methods like " +
                            "\"a string\".length or [\"a\", \"list\"].insert. If you want to help in testing it out and fixing bugs, feel free to" +
                            " download the latest version of ezr² RE from the ezr² GitHub releases page and compiling it using the .NET SDK and/or" +
                            " Visual Studio. The GitHub releases page is: https://github.com/Uralstech/ezrSquared/releases."
                        )
                    }
                }
            },

            AnswerStyle = GeminiAnswerStyle.Verbose,
        }
    );

    if (response.Answer.Content != null)
        Debug.Log($"Gemini's answer: {response.Answer.Content.Parts[^1].Text}");
    
    foreach (GeminiGroundingAttribution attribution in response.Answer.GroundingAttributions)
        Debug.Log($"Attribution ID: {attribution.SourceId.GroundingPassage.PassageId} | Content: {attribution.Content.Parts[^1].Text}");
}
```

See [GeminiAnswerResponse](~/api/Uralstech.UGemini.Models.Generation.QuestionAnswering.GeminiAnswerResponse.yml) and [GeminiAnswerRequest](~/api/Uralstech.UGemini.Models.Generation.QuestionAnswering.GeminiAnswerRequest.yml) for more details.

### CountTokens

> Runs a model's tokenizer on input Content and returns the token count.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.Models;
using Uralstech.UGemini.Models.Content;
using Uralstech.UGemini.Models.CountTokens;

private async void RunTokenCountRequest()
{
    Debug.Log("Running token counting request.");

    GeminiTokenCountResponse response = await GeminiManager.Instance.Request<GeminiTokenCountResponse>(
        new GeminiTokenCountRequest(GeminiModel.Gemini1_5Flash)
        {
            Contents = new GeminiContent[]
            {
                GeminiContent.GetContent("Hello! How are you?"),
            }
        }
    );

    Debug.Log($"Tokens: {response.TotalTokens}");
}
```

See [GeminiTokenCountResponse](~/api/Uralstech.UGemini.Models.CountTokens.GeminiTokenCountResponse.yml) and [GeminiTokenCountRequest](~/api/Uralstech.UGemini.Models.CountTokens.GeminiTokenCountRequest.yml) for more details.

## TunedModels (Unstable)

> The TunedModels endpoint contains methods that allow you to access and inference fine-tuned Gemini models.

### GenerateContent

> Generates a model response given an input GenerateContentRequest.

```csharp
// This is untested code.

using Uralstech.UGemini;
using Uralstech.UGemini.Models.Content;
using Uralstech.UGemini.Models.Generation.Chat;

private async void RunTunedModelChatRequest()
{
    Debug.Log("Running chat request on tuned model.");

    GeminiChatResponse response = await GeminiManager.Instance.Request<GeminiChatResponse>(
        new GeminiChatRequest("tunedModels/modelname")
        {
            Contents = new GeminiContent[]
            {
                GeminiContent.GetContent("What's up?")
            },
        }
    );
    
    Debug.Log($"Tuned Gemini's response: {response.Parts[^1].Text}");
}
```

See [GeminiChatResponse](~/api/Uralstech.UGemini.Models.Generation.Chat.GeminiChatResponse.yml) and [GeminiChatRequest](~/api/Uralstech.UGemini.Models.Generation.Chat.GeminiChatRequest.yml) for more details.

## Files (Beta API)

> The Gemini File API can be used to store data on the cloud for future prompting with the Gemini models.

### Delete

> Deletes the File.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.FileAPI;

private async void RunDeleteFileRequest(string fileId)
{
    Debug.Log("Deleting file...");
    await GeminiManager.Instance.Request(new GeminiFileDeleteRequest(fileId));
    Debug.Log("File deleted.");
}
```

See [GeminiFileDeleteRequest](~/api/Uralstech.UGemini.FileAPI.GeminiFileDeleteRequest.yml) for more details.

### Get

> Gets the metadata for the given File.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.FileAPI;

private async Task<GeminiFile> RunGetFileRequest(string fileId)
{
    return await GeminiManager.Instance.Request<GeminiFile>(new GeminiFileGetRequest(fileId));
}
```

See [GeminiFile](~/api/Uralstech.UGemini.FileAPI.GeminiFile.yml) and [GeminiFileGetRequest](~/api/Uralstech.UGemini.FileAPI.GeminiFileGetRequest.yml) for more details.

### List

> Lists the metadata for Files owned by the requesting project.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.FileAPI;

private async Task<GeminiFile[]> RunListFilesRequest(int maxFiles = 10, string pageToken = null)
{
    GeminiFileListResponse response = await GeminiManager.Instance.Request<GeminiFileListResponse>(new GeminiFileListRequest()
    {
        MaxResponseFiles = maxFiles,
        PageToken = string.IsNullOrWhiteSpace(pageToken) ? string.Empty : pageToken,
    });

    return response?.Files;
}
```

See [GeminiFileListResponse](~/api/Uralstech.UGemini.FileAPI.GeminiFileListResponse.yml) and [GeminiFileListRequest](~/api/Uralstech.UGemini.FileAPI.GeminiFileListRequest.yml) for more details.

## Media (Beta API)

> The Gemini File API can be used to store data on the cloud for future prompting with the Gemini models.

### Upload

> Creates a File.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.FileAPI;

private async Task<GeminiFile> RunUploadFileRequest(string text)
{
    GeminiFileUploadResponse response = await GeminiManager.Instance.Request<GeminiFileUploadResponse>(new GeminiFileUploadRequest(GeminiContentType.TextPlain.MimeType())
    {
        File = new GeminiFileUploadMetaData()
        {
            DisplayName = "I'm a File",
        },
        RawData = Encoding.UTF8.GetBytes(text)
    });
    
    return response.File;
}
```

See [GeminiFileUploadResponse](~/api/Uralstech.UGemini.FileAPI.GeminiFileUploadResponse.yml) and [GeminiFileUploadRequest](~/api/Uralstech.UGemini.FileAPI.GeminiFileUploadRequest.yml) for more details.
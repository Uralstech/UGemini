# QuickStart and Documentation

[TOC]

## Basics

### Setup

Add an instance of `Uralstech.UGemini.GeminiManager` to your scene, and set it up with your Gemini API key. You can get your API key from [*here*](https://makersuite.google.com/app/apikey).

### GeminiManager

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

### Beta API

`GeminiManager` supports both the `v1` and `v1beta` Gemini API versions. As a lot of features are still unsupported in the main `v1` API, you may
need to use the Beta API. You can set the `useBetaApi` boolean parameter in the request's constructor to do so.

### Models

`Uralstech.UGemini.Models.GeminiModel` has four static model IDs:

- [`Gemini1_5Flash`](https://ai.google.dev/gemini-api/docs/models/gemini#gemini-1.5-flash)
- [`Gemini1_5Pro`](https://ai.google.dev/gemini-api/docs/models/gemini#gemini-1.5-pro)
- [`Gemini1_0Pro`](https://ai.google.dev/gemini-api/docs/models/gemini#gemini-1.0-pro)
- [`Gemini1_0ProVision`](https://ai.google.dev/gemini-api/docs/models/gemini#gemini-1.0-pro-vision)
    - Gemini 1.0 Pro Vision is deprecated. Use Use 1.5 Flash (`Gemini1_5Flash`) or 1.5 Pro (`Gemini1_5Pro`) instead.
- [`TextEmbedding004`](https://ai.google.dev/gemini-api/docs/models/gemini#text-embedding)
- [`Aqa`](https://ai.google.dev/gemini-api/docs/models/gemini#aqa)

You can provide these to the `model` parameter in the constructors for model-related requests.
UGemini can also implicitly convert `string` model IDs to `GeminiModelId` objects.

### QuickStart: Multi-turn Chat Request

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


## All Supported Endpoints

### Models

> The Models endpoint contains methods that allow you to access and inference Gemini models.

#### Get

> Gets information about a specific Model such as its version number, token limits, parameters and other metadata.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.Models;

private async Task<GeminiModel> RunGetModelRequest(string modelId)
{
    return await GeminiManager.Instance.Request<GeminiModel>(new GeminiModelGetRequest(modelId));
}
```

See \ref Uralstech.UGemini.Models.GeminiModel "GeminiModel" and \ref Uralstech.UGemini.Models.GeminiModelGetRequest "GeminiModelGetRequest" for more details.

Newer models will not be recognized by the request if you're not using the Beta API.

#### List

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

See \ref Uralstech.UGemini.Models.GeminiModelListResponse "GeminiModelListResponse" and \ref Uralstech.UGemini.Models.GeminiModelListRequest "GeminiModelListRequest" for more details.

Newer models will not be recognized by the request if you're not using the Beta API.

#### EmbedContent

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

See \ref Uralstech.UGemini.Models.Embedding.GeminiEmbedContentResponse "GeminiEmbedContentResponse" and \ref Uralstech.UGemini.Models.Embedding.GeminiEmbedContentRequest "GeminiEmbedContentRequest" for more details.

#### BatchEmbedContents

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

See \ref Uralstech.UGemini.Models.Embedding.GeminiBatchEmbedContentResponse "GeminiBatchEmbedContentResponse" and \ref Uralstech.UGemini.Models.Embedding.GeminiBatchEmbedContentRequest "GeminiBatchEmbedContentRequest" for more details.

#### GenerateContent

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

See \ref Uralstech.UGemini.Models.Generation.Chat.GeminiChatResponse "GeminiChatResponse" and \ref Uralstech.UGemini.Models.Generation.Chat.GeminiChatRequest "GeminiChatRequest" for more details.

#### StreamGenerateContent

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

See \ref Uralstech.UGemini.Models.Generation.Chat.GeminiChatResponse "GeminiChatResponse" and \ref Uralstech.UGemini.Models.Generation.Chat.GeminiChatRequest "GeminiChatRequest" for more details.

#### GenerateAnswer	(Beta API)

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

See \ref Uralstech.UGemini.Models.Generation.QuestionAnswering.GeminiAnswerResponse "GeminiAnswerResponse" and \ref Uralstech.UGemini.Models.Generation.QuestionAnswering.GeminiAnswerRequest "GeminiAnswerRequest" for more details.

#### CountTokens

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

See \ref Uralstech.UGemini.Models.CountTokens.GeminiTokenCountResponse "GeminiTokenCountResponse" and \ref Uralstech.UGemini.Models.CountTokens.GeminiTokenCountRequest "GeminiTokenCountRequest" for more details.

### TunedModels (Unstable)

> The TunedModels endpoint contains methods that allow you to access and inference fine-tuned Gemini models.

#### GenerateContent

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

See \ref Uralstech.UGemini.Models.Generation.Chat.GeminiChatResponse "GeminiChatResponse" and \ref Uralstech.UGemini.Models.Generation.Chat.GeminiChatRequest "GeminiChatRequest" for more details.

### Files (Beta API)

> The Gemini File API can be used to store data on the cloud for future prompting with the Gemini models.

#### Delete

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

See \ref Uralstech.UGemini.FileAPI.GeminiFileDeleteRequest "GeminiFileDeleteRequest" for more details.

#### Get

> Gets the metadata for the given File.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.FileAPI;

private async Task<GeminiFile> RunGetFileRequest(string fileId)
{
    return await GeminiManager.Instance.Request<GeminiFile>(new GeminiFileGetRequest(fileId));
}
```

See \ref Uralstech.UGemini.FileAPI.GeminiFile "GeminiFile" and \ref Uralstech.UGemini.FileAPI.GeminiFileGetRequest "GeminiFileGetRequest" for more details.

#### List

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

See \ref Uralstech.UGemini.FileAPI.GeminiFileListResponse "GeminiFileListResponse" and \ref Uralstech.UGemini.FileAPI.GeminiFileListRequest "GeminiFileListRequest" for more details.

### Media (Beta API)

> The Gemini File API can be used to store data on the cloud for future prompting with the Gemini models.

#### Upload

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

See \ref Uralstech.UGemini.FileAPI.GeminiFileUploadResponse "GeminiFileUploadResponse" and \ref Uralstech.UGemini.FileAPI.GeminiFileUploadRequest "GeminiFileUploadRequest" for more details.

## GeminiChatRequest Features

### Streaming Responses

`GeminiChatRequest` allows you to stream Gemini's response in real-time. You can do so by using `GeminiManager.StreamRequest` and
utilizing the callback in `GeminiChatRequest`.

You can even stream function calls! Check out the `Streaming Generated Content` sample included in the package.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.Models;
using Uralstech.UGemini.Models.Content;
using Uralstech.UGemini.Models.Generation.Chat;

[SerializeField] private Text _chatResponse;

private async Task<string> OnChat(string text)
{
    GeminiChatResponse response = await GeminiManager.Instance.StreamRequest(new GeminiChatRequest(GeminiModel.Gemini1_5Flash)
    {
        Contents = new GeminiContent[]
        {
            GeminiContent.GetContent(text, GeminiRole.User),
        },
    
        OnPartialResponseReceived = streamedResponse =>
        {
            _chatResponse.text = streamedResponse.Parts[0].Text;
            return Task.CompletedTask;
        }
    });

    return response.Parts[0].Text;
}
```

If you do not want to use the callback, you can let the `StreamRequest` task run in the background, and access the streamed data from the
`GeminiChatRequest.StreamedResponse` property.

### Adding Media Content to Requests

`GeminiContent.Parts` contains the actual contents of each chat request and response. You can add media content to the `Parts` array, but you must only have
one type of data in each part, like one part of text, one part of an image, and so on. The following samples shows data being read from a file and into a
`GeminiContent` object.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.Models.Content;

private async Task<GeminiContent> GetFileContent(string filePath, GeminiContentType contentType)
{
    byte[] data;
    try
    {
        data = await File.ReadAllBytesAsync(filePath);
    }
    catch (SystemException exception)
    {
        Debug.LogError($"Failed to load file: {exception.Message}");
        return null;
    }

    return new GeminiContent()
    {
        Parts = new GeminiContentPart[]
        {
            new GeminiContentPart()
            {
                Text = "What's in this file?"
            },
            new GeminiContentPart()
            {
                InlineData = new GeminiContentBlob()
                {
                    MimeType = contentType,
                    Data = Convert.ToBase64String(data)
                }
            }
        }
    };
}
```

Now, the `GeminiContent` returned by the method can be fed into a chat request!

#### Utility Methods

`GeminiContent` and `GeminiContentBlob` also contain static utility methods to help
create them from Unity types like `AudioClip` or `Texture2D`:

- `GeminiContent.GetContent`
    - Can convert `string` messages, `Texture2D` images, `AudioClip`\* audio and `GeminiFile` data to `GeminiContent` objects.

- `GeminiContentBlob.GetContentBlob`
    - Can convert `Texture2D` images and `AudioClip`\* audio to `GeminiContentBlob` objects.

\*Requires [*Utilities.Encoding.Wav*](https://openupm.com/packages/com.utilities.encoder.wav/).

### Function Calling

First, we have to setup our tools and define our function schemas.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.Models;
using Uralstech.UGemini.Models.Content;
using Uralstech.UGemini.Models.Generation.Chat;
using Uralstech.UGemini.Models.Generation.Schema;
using Uralstech.UGemini.Models.Generation.Tools;
using Uralstech.UGemini.Models.Generation.Tools.Declaration;

private GeminiTool _geminiFunctions = new GeminiTool()
{
    FunctionDeclarations = new GeminiFunctionDeclaration[]
    {
        new GeminiFunctionDeclaration()
        {
            Name = "printToConsole",
            Description = "Print text to the user's console.",
            Parameters = new GeminiSchema()
            {
                Type = GeminiSchemaDataType.Object,
                Properties = new Dictionary<string, GeminiSchema>()
                {
                    {
                        "text", new GeminiSchema()
                        {
                            Type = GeminiSchemaDataType.String,
                            Description = "The text to print. e.g. \"Hello, World!\"",
                            Nullable = false,
                        }
                    },
                },
                Required = new string[] { "text" },
            }
        },

        new GeminiFunctionDeclaration()
        {
            Name = "changeTextColor",
            Description = "Change the color of the text.",
            Parameters = new GeminiSchema()
            {
                Type = GeminiSchemaDataType.Object,
                Properties = new Dictionary<string, GeminiSchema>()
                {
                    {
                        "color", new GeminiSchema()
                        {
                            Type = GeminiSchemaDataType.String,
                            Description = "The color to set. e.g. \"BLUE\"",
                            Format = GeminiSchemaDataFormat.Enum,
                            Enum = new string[]
                            {
                                "RED",
                                "GREEN",
                                "BLUE",
                                "WHITE",
                            },
                            Nullable = false,
                        }
                    },
                },
                Required = new string[] { "color" },
            }
        }
    },
};
```

For each function, we need a declaration with a name and description. The parameters are an object of type `GeminiSchema`, which defines the
schema of each of the parameters. The type is of `GeminiSchemaDataType.Object`, and contains the dictionary of parameter schemas.

The keys of the dictionary should be the parameter name, and the values should be `GeminiSchema` objects which define the type, description,
format, etc. of the parameter.

Finally, we have the `Required` property which tells Gemini which fields are absolutely required in each call. Now, we can move on to the chat.

```csharp
[SerializeField] private Text _chatResponse;

private async Task<string> OnChat(string text)
{
    List<GeminiContent> contents = new()
    {
        GeminiContent.GetContent(text, GeminiRole.User),
    };
    
    GeminiChatResponse response;
    GeminiFunctionCall functionCall;
    string responseText = string.Empty;
    do
    {
        response = await GeminiManager.Instance.Request<GeminiChatResponse>(new GeminiChatRequest(GeminiModel.Gemini1_5Flash, true)
        {
            Contents = contents.ToArray(),
            Tools = new GeminiTool[] { _geminiFunctions },
            ToolConfig = GeminiToolConfiguration.GetConfiguration(GeminiFunctionCallingMode.Any),
        });

        // Don't forget to do this! If the function call is not added to the chat
        // history, Gemini will throw an error when receiving the response!
        contents.Add(response.Candidates[0].Content);

        responseText = Array.Find(response.Parts, part => !string.IsNullOrEmpty(part.Text))?.Text;
        GeminiContentPart[] allFunctionCalls = Array.FindAll(response.Parts, part => part.FunctionCall != null);

        functionCall = null;
        for (int i = 0; i < allFunctionCalls.Length; i++)
        {
            functionCall = allFunctionCalls[i].FunctionCall;
            JObject functionResponse = null;

            switch (functionCall.Name)
            {
                case "printToConsole":
                    Debug.Log(functionCall.Arguments["text"].ToObject<string>());
                    break;

                case "changeTextColor":
                    if (!TryChangeTextColor(functionCall.Arguments["color"].ToObject<string>()))
                    {
                        functionResponse = new JObject()
                        {
                            ["result"] = "Unknown color."
                        };
                    }

                    break;

                default:
                    functionResponse = new JObject()
                    {
                        ["result"] = "Sorry, but that function does not exist."
                    };

                    break;
            }

            contents.Add(GeminiContent.GetContent(functionCall.GetResponse(functionResponse ?? new JObject()
            {
                ["result"] = "Completed executing function successfully."
            })));
        }
    } while (functionCall != null);

    _chatResponse.text = responseText;
    return responseText;
}

private bool TryChangeTextColor(string color)
{
    switch (color)
    {
        case "RED":
            _chatResponse.color = Color.red; break;

        case "GREEN":
            _chatResponse.color = Color.green; break;

        case "BLUE":
            _chatResponse.color = Color.blue; break;

        case "WHITE":
            _chatResponse.color = Color.white; break;

        default:
            return false;
    }

    Debug.Log("Changed text color!");
    return true;
}
```

Here, we are going through each response, checking if a function was called, and calling the requested function.

The response is a JSON object, which is optional, but it is recommended to include. Note the use of `GeminiToolConfiguration.GetConfiguration`,
which is a utility method to create a `GeminiToolConfiguration` with the given `GeminiFunctionCallingMode`. Here, it is `GeminiFunctionCallingMode.Any`,
which means Gemini will always call at least one function in each conversation.

After the function is called, we respond by adding the calls and responses to the history. We use the `GetResponse` utility method to get a
`GeminiFunctionResponse` object with the response JSON.

Function calling is, as of writing, only available in the Beta API.

### JSON Response Mode

In JSON mode, Gemini will always respond in the specified JSON response schema.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.Models;
using Uralstech.UGemini.Models.Content;
using Uralstech.UGemini.Models.Generation;
using Uralstech.UGemini.Models.Generation.Chat;
using Uralstech.UGemini.Models.Generation.Schema;

private async Task<string> OnChat(string text)
{
    // Note: It seems GeminiModel.Gemini1_5Flash is not very good at JSON.
    GeminiChatResponse response = await GeminiManager.Instance.Request<GeminiChatResponse>(new GeminiChatRequest(GeminiModel.Gemini1_5Pro, true)
    {
        Contents = new GeminiContent[]
        {
            GeminiContent.GetContent(text, GeminiRole.User),
        },
        SystemInstruction = GeminiContent.GetContent("You are a helpful math teacher who teacher their students mathematics in the most helpful way possible."),
        GenerationConfig = new GeminiGenerationConfiguration()
        {
            ResponseMimeType = GeminiResponseType.Json,
            ResponseSchema = new GeminiSchema()
            {
                Type = GeminiSchemaDataType.Array,
                Description = "A list of mathematical expressions.",
                Items = new GeminiSchema()
                {
                    Type = GeminiSchemaDataType.Object,
                    Properties = new Dictionary<string, GeminiSchema>()
                    {
                        {
                            "expression", new GeminiSchema()
                            {
                                Type = GeminiSchemaDataType.String,
                            }
                        },
                        {
                            "explanation", new GeminiSchema()
                            {
                                Type = GeminiSchemaDataType.String,
                            }
                        },
                    },
                    Required = new string[] { "expression", "explanation", },
                },
            },
        }
    });

    return response.Parts[0].Text;
}
```

Here, we used a schema for an array of objects, which contain two parameters: `expression` and `explanation`.
We have told Gemini to split the response into the parameters, where a mathematical expression and its explanation is given.

The `GeminiSchema` object is the same type used for function calling.

JSON mode is also only available in the Beta API.

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
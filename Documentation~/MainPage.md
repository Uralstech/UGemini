# QuickStart and Documentation

[TOC]

### Setup

Add an instance of `GeminiManager` to your scene, and set it up with your Gemini API key. You can get your API key from [*here*](https://makersuite.google.com/app/apikey).

### GeminiManager

There are only two methods in `GeminiManager`:

| Method            | What it does                                      |
| -------------     | -------------                                     |
| `SetApiKey`       | Sets the Gemini API key through code              |
| `Request`         | Computes a request on the Gemini API              |
| `StreamRequest`*  | Computes a streaming request on the Gemini API    |

*Requires `Utilities.Async` package.

All computations on the Gemini API are done through `GeminiManager.Request`, `GeminiManager.StreamRequest` and their variants.

In this documentation, the fields and properties of each type will not be explained. Every type has been fully documented in code, so
please check the code docstrings to learn more about each type.

#### Beta API

`GeminiManager` supports both the `v1` and `v1beta` Gemini API versions. As a lot of features are still unsupported in the main `v1` API, you may
need to use the Beta API. You can set the `useBetaApi` boolean parameter in the request constructor to do so.

#### Models

`GeminiModel` from `Uralstech.UGemini.Models` has four static model IDs:

- [`Gemini1_5Flash`](https://ai.google.dev/gemini-api/docs/models/gemini#gemini-1.5-flash)
- [`Gemini1_5Pro`](https://ai.google.dev/gemini-api/docs/models/gemini#gemini-1.5-pro)
- [`Gemini1_0Pro`](https://ai.google.dev/gemini-api/docs/models/gemini#gemini-1.0-pro)
- [`Gemini1_0ProVision`](https://ai.google.dev/gemini-api/docs/models/gemini#gemini-1.0-pro-vision)
    - Gemini 1.0 Pro Vision is deprecated. Use Use 1.5 Flash (`Gemini1_5Flash`) or 1.5 Pro (`Gemini1_5Pro`) instead.
- [`TextEmbedding004`](https://ai.google.dev/gemini-api/docs/models/gemini#text-embedding)
- [`Aqa`](https://ai.google.dev/gemini-api/docs/models/gemini#aqa)

You can provide these to the `model` parameter in the constructors for model-related requests.
UGemini can also implicitly convert `string` model IDs to `GeminiModelId` objects.

#### QuickStart: generateContent (Chat) Request

This is a simple request that asks Gemini a question and logs the response to the console.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.Chat;
using Uralstech.UGemini.Models;

async void QueryGemini()
{
    string text = "Hello! How are you doing?";
    GeminiChatResponse response = await GeminiManager.Instance.Request<GeminiChatResponse>(
        new GeminiChatRequest(GeminiModel.Gemini1_5Flash)
        {
            Contents = new GeminiContent[]
            {
                GeminiContent.GetContent(text, GeminiRole.User),
            },
        }
    );

    Debug.Log(response.Parts[0].Text);
}
```

That's all! We give a request argument of type `GeminiChatRequest`, specify that we expect a response of type `GeminiChatResponse`, and voilà!
We've got the response in `response.Parts[0].Text`!

#### QuickStart: Multi-turn generateContent Request

This is a simple method that maintains the user's chat history with Gemini.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.Chat;
using Uralstech.UGemini.Models;

List<GeminiContent> _chatHistory = new();

async Task<string> OnChat(string text)
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

### GeminiChatRequest In-Depth

Available in the `Uralstech.UGemini.Chat` namespace. Generates content from the given model by running a `generateContent` request.

#### Streaming Responses

`GeminiChatRequest` allows you to stream Gemini's response in real-time. You can do so by using `GeminiManager.StreamRequest` and
utilizing the callback in `GeminiChatRequest`.

You can even stream function calls! Check out the `Streaming Generated Content` sample included in the package.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.Chat;
using Uralstech.UGemini.Models;

[SerializeField] Text _chatResponse;

async Task<string> OnChat(string text)
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

#### Adding Media Content to Requests

`GeminiContent.Parts` contains the actual contents of each chat request and response. You can add media content to the `Parts` array, but you must only have
one type of data in each part, like one part of text, one part of an image, and so on. The following samples shows data being read from a file and into a
`GeminiContent` object.

```csharp
using Uralstech.UGemini;

async Task<GeminiContent> GetFileContent(string filePath, GeminiContentType contentType)
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

##### Utility Methods

`GeminiContent` and `GeminiContentBlob` also contain static utility methods to help
create them from Unity types like `AudioClip` or `Texture2D`:

- `GeminiContent.GetContent`
    - Can convert `string` messages, `Texture2D` images, `AudioClip`* audio and `GeminiFile` data to `GeminiContent` objects.

- `GeminiContentBlob.GetContentBlob`
    - Can convert `Texture2D` images and `AudioClip`* audio to `GeminiContentBlob` objects.

*Requires [*Utilities.Encoding.Wav*](https://openupm.com/packages/com.utilities.encoder.wav/).

#### Function Calling

First, we have to setup our tools and define our function schemas.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.Chat;
using Uralstech.UGemini.Models;
using Uralstech.UGemini.Schema;
using Uralstech.UGemini.Tools;
using Uralstech.UGemini.Tools.Declaration;

GeminiTool _geminiFunctions = new GeminiTool()
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
[SerializeField] Text _chatResponse;

async Task<string> OnChat(string text)
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

bool TryChangeTextColor(string color)
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

#### JSON Response Mode

In JSON mode, Gemini will always respond in the specified JSON response schema.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.Chat;
using Uralstech.UGemini.Models;
using Uralstech.UGemini.Schema;

async Task<string> OnChat(string text)
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

### Model Metadata

The `Uralstech.UGemini.Models` namespace has request types to help retrieve metadata of Gemini models through `GeminiModelGetRequest` and `GeminiModelListRequest`.

#### GeminiModelGetRequest

Gets information about a specific model by running a `get` request.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.Models;

async Task<GeminiModel> GetModel(string modelId)
{
    return await GeminiManager.Instance.Request<GeminiModel>(new GeminiModelGetRequest(modelId));
}
```

We just give the unique ID of the model, like `gemini-pro` or `gemini-1.5-flash`, and we get a `GeminiModel` object as the response!

Just one thing to note: the newer models will not be recognized by the request if you're not using the Beta API.

#### GeminiModelListRequest

Gets information about all models by running a `list` request.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.Models;

async Task<GeminiModel[]> ListModels(int maxModels = 50, string pageToken = string.Empty)
{
    GeminiModelListResponse response = await GeminiManager.Instance.Request<GeminiModelListResponse>(new GeminiModelListRequest()
    {
        MaxResponseModels = maxModels,
        PageToken = string.IsNullOrWhiteSpace(pageToken) ? string.Empty : pageToken,
    });

    return response?.Models;
}
```

`MaxResponseModels` is the total number of pages you want to retrieve in each request, and `PageToken` is the 'identifier' for the requested page
in the multiple pages of file metadata. You can leave it empty to get the first page, and use `response.NextPageToken` as the token for
for the next page, and run the request again with it.

Again, the newer models will not be recognized by the request if you're not using the Beta API.

### GeminiTokenCountRequest

Available in the `Uralstech.UGemini.TokenCounting` namespace. Counts the number of tokens in the
given request contents for the given model by running a `countTokens` request.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.Models;
using Uralstech.UGemini.TokenCounting;

async Task<int> CountTokens(string text)
{
    GeminiTokenCountResponse response = await GeminiManager.Instance.Request<GeminiTokenCountResponse>(new GeminiTokenCountRequest(GeminiModel.Gemini1_5Flash)
    {
        Contents = new GeminiContent[]
        {
            GeminiContent.GetContent(text, GeminiRole.User),
        },
    });
    
    return response.TotalTokens;
}
```

We just include the content to count the tokens of and send the request! You can also have
a whole `GeminiChatRequest` as an argument in `GeminiTokenCountRequest.CompleteRequest` for
the token counting request to see how much a chat request has/will cost you.

### File API

The Gemini File API can be used to store data on the cloud for future prompting with the Gemini models. The code for most of these requests is very simple.

All File API types are available in the `Uralstech.UGemini.FileAPI` namespace. The File API is only available in the Beta API.

#### Uploading Files

Uploads a file to be available through the File API by running an `upload` request.
    
```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.FileAPI;

async Task<GeminiFile> UploadFile(string text)
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

That's it! Convert your data to a byte array and just give the right MIME type as an argument!
Setting the file upload metadata is optional.

Please note that setting `GeminiFileUploadMetaData.Name` will always throw an error and it seems
to be an API issue.

#### Listing All Files

Requests the metadata for all existing files uploaded to the File API by running a `list` request.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.FileAPI;

async Task<GeminiFile[]> ListFiles(int maxFiles = 10, string pageToken = string.Empty)
{
    GeminiFileListResponse response = await GeminiManager.Instance.Request<GeminiFileListResponse>(new GeminiFileListRequest()
    {
        MaxResponseFiles = maxFiles,
        PageToken = string.IsNullOrWhiteSpace(pageToken) ? string.Empty : pageToken,
    });

    return response?.Files;
}
```

`MaxResponseFiles` is the total number of pages you want to retrieve in each request, and `PageToken` is the 'identifier' for the requested page
in the multiple pages of file metadata. You can leave it empty to get the first page, and use `response.NextPageToken` as the token for
for the next page, and run the request again with it.

#### Retrieving File Metadata

Requests metadata for a single file uploaded to the File API by running a `get` request.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.FileAPI;

async Task<GeminiFile> GetFile(string fileId)
{
    return await GeminiManager.Instance.Request<GeminiFile>(new GeminiFileGetRequest(fileId));
}
```

Just put in the file's ID! You can get it from the `GeminiFile.Name` property, but remember to remove the "files/" prefix.

#### Deleting a File

Deletes a file uploaded to the File API by running a `delete` request.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.FileAPI;

async void DeleteFile(string fileId)
{
    await GeminiManager.Instance.Request(new GeminiFileDeleteRequest(fileId));
    Debug.Log("File deleted.");
}
```

Again, just put in the file's ID!

### Samples

For full-fledged examples of the features of this package, check out the samples included in the package:

#### Mult-turn Chat

A sample scene showing a multi-turn chat system. [***GitHub Source***](https://github.com/Uralstech/UGemini/tree/master/UGemini/Packages/com.uralstech.ugemini/Samples~/SimpleMultiTurnChatSample)

#### Function Calling

A sample scene showing a function calling system. [***GitHub Source***](https://github.com/Uralstech/UGemini/tree/master/UGemini/Packages/com.uralstech.ugemini/Samples~/FunctionCallingSample)

#### Streaming Generated Content

A sample showing a system which streams Gemini's responses, including function calls. [***GitHub Source***](https://github.com/Uralstech/UGemini/tree/master/UGemini/Packages/com.uralstech.ugemini/Samples~/StreamedFunctionCallingSample)

#### Question Answering

A sample scene with a system where Gemini answers questions based only on the given context. [***GitHub Source***](https://github.com/Uralstech/UGemini/tree/master/UGemini/Packages/com.uralstech.ugemini/Samples~/QuestionAnsweringSample)

#### Prompting with File API

A sample scene with a system to create, delete, retrieve, list and prompt Gemini with files stored in the File/Media API endpoints. [***GitHub Source***](https://github.com/Uralstech/UGemini/tree/master/UGemini/Packages/com.uralstech.ugemini/Samples~/FileAPISample)

#### JSON Response

A sample scene showing a system where Gemini responds in a specified JSON format. [***GitHub Source***](https://github.com/Uralstech/UGemini/tree/master/UGemini/Packages/com.uralstech.ugemini/Samples~/JSONResponseSample)

#### List and Get Model Metadata

A sample scene with a system to list, get and chat with models using the models.get and models.list endpoints. [***GitHub Source***](https://github.com/Uralstech/UGemini/tree/master/UGemini/Packages/com.uralstech.ugemini/Samples~/ModelMetadataRetrievalSample)

#### Token Counting

A sample scene showing a token counting system using the `countTokens` endpoint. [***GitHub Source***](https://github.com/Uralstech/UGemini/tree/master/UGemini/Packages/com.uralstech.ugemini/Samples~/TokenCounterSample)
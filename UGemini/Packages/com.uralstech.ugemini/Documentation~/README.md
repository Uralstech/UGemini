## UGemini Documentation

### DEPRECATION NOTICE

`GeminiManager.Compute` and parts of related types have been deprecated. Please check `README_OLD.md` for documentation regarding the deprecated code.

### Setup

Add an instance of `GeminiManager` to your scene, and set it up with your Gemini API key. You can get your API key from [*here*](https://makersuite.google.com/app/apikey).

### Main API

There are only two methods in `GeminiManager`:

| Method            | What it does                          |
| -------------     | -------------                         |
| `SetApiKey`       | Sets the Gemini API key through code  |
| `Request`         | Computes a request on the Gemini API  |

All computations on the Gemini API are done through `GeminiManager.Request` and its variants.

In this documentation, the fields and properties of each type will not be explained. Every type has been fully documented in code, so
please check the code docstrings to learn more about each type.

#### Beta API

`GeminiManager` supports both the `v1` and `v1beta` Gemini API versions. As a lot of features are still unsupported in the main `v1` API, you may
need to use the beta API. You can set the `useBetaApi` boolean parameter in the request constructor to do so.

#### Models

`GeminiManager` has four constant model IDs:

- `Gemini1_5Flash` - [*Gemini 1.5 Flash*](https://ai.google.dev/gemini-api/docs/models/gemini#gemini-1.5-flash)

- `Gemini1_5Pro` - [*Gemini 1.5 Pro*](https://ai.google.dev/gemini-api/docs/models/gemini#gemini-1.5-pro)

- `Gemini1_0Pro` - [*Gemini 1.0 Pro*](https://ai.google.dev/gemini-api/docs/models/gemini#gemini-1.0-pro)

- `Gemini1_0ProVision` - [*Gemini 1.0 Pro Vision*](https://ai.google.dev/gemini-api/docs/models/gemini#gemini-1.0-pro-vision)
    - Gemini 1.0 Pro Vision is deprecated. Use Use 1.5 Flash (`Gemini1_5Flash`) or 1.5 Pro (`Gemini1_5Pro`) instead.


By default, all model requests use the [*Gemini 1.5 Flash*](https://ai.google.dev/gemini-api/docs/models/gemini#gemini-1.5-flash)
model. This can be changed by either providing a string ID or one of the constants to the `model` parameter in the request constructor.

#### Simple GenerateContent (Chat) Request

This is a simple request that asks Gemini a question and logs the response to the console.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.Chat;

async void QueryGemini()
{
    string text = "Hello! How are you doing?";
    GeminiChatResponse response = await GeminiManager.Instance.Request<GeminiChatResponse>(
        new GeminiChatRequest(GeminiManager.Gemini1_5Flash)
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

These are all the types of requests and endpoints that are supported:

- `GeminiChatRequest` | `GeminiChatResponse`:
    - Available in the `Uralstech.UGemini.Chat` namespace
    - Generates content from the given model
    - Runs a `generateContent` request on the model

- `GeminiTokenCountRequest` | `GeminiTokenCountResponse`:
    - Available in the `Uralstech.UGemini.TokenCounting` namespace
    - Counts the number of tokens in the given request contents for the given model
    - Runs a `countTokens` request on the model
    
- *`GeminiFileUploadRequest` | `GeminiFileUploadResponse` 🚧:
    - Available in the `Uralstech.UGemini.FileAPI` namespace
    - Uploads a file to be available through the File API
    - Runs an `upload` request on the File/Media API
    
- *`GeminiFileListRequest` | `GeminiFileListResponse`:
    - Available in the `Uralstech.UGemini.FileAPI` namespace
    - Requests metadata for all existing files uploaded to the File API
    - Runs a `list` request on the File API
    
- *`GeminiFileGetRequest` | `GeminiFile`:
    - Available in the `Uralstech.UGemini.FileAPI` namespace
    - Requests metadata for a single file uploaded to the File API
    - Runs a `get` request on the File API
    
- *`GeminiFileDeleteRequest`:
    - Available in the `Uralstech.UGemini.FileAPI` namespace
    - Deletes a file uploaded to the File API
    - Runs a `delete` request on the File API
    
🚧 - The feature is being worked on and is unstable

*Part of the File API. More about it further down in the documentation.

#### Multi-turn Chat Request

This is a simple method that maintains the user's chat history with Gemini.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.Chat;

List<GeminiContent> _chatHistory = new();

async Task<string> OnChat(string text)
{
    _chatHistory.Add(GeminiContent.GetContent(text, GeminiRole.User));
    GeminiChatResponse response = await GeminiManager.Instance.Request<GeminiChatResponse>(
        new GeminiChatRequest(GeminiManager.Gemini1_5Flash)
        {
            Contents = _chatHistory.ToArray(),
        }
    );
    
    _chatHistory.Add(response.Candidates[0].Content);
    return response.Parts[0].Text;
}
```

Here, we simply have a list of `GeminiContent` objects, which tracks the messages of the conversation. Every time `OnChat` is called, the user's request and
the model's reply are added the the list. That is all!

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

`GeminiContent` and `GeminiContentBlob` also contain static utility methods to help
create them from Unity types like `AudioClip` or `Texture2D`:

- `GeminiContent.GetContent`
    - Can convert `string` messages, `Texture2D` images, *`AudioClip` audio and **`GeminiFile` data to `GeminiContent` objects.

- `GeminiContentBlob.GetContentBlob`
    - Can convert `Texture2D` images and *`AudioClip` audio to `GeminiContentBlob` objects.

*Requires [*Utilities.Encoding.Wav*](https://openupm.com/packages/com.utilities.encoder.wav/).
**More about this further down in the documentation.

#### Function Calling

First, we have to setup our tools and define our function schemas.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.Chat;
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

The key of the dictionary should be the parameter name, and the value should be another `GeminiSchema` object which defines the type, description,
format, etc. of the parameter.

Finally, we have the `Required` property which tells Gemini which fields are absolutely required in each call.

Now, we can move on to the chat.

```csharp
[SerializeField] private Text _chatResponse;

public async Task<string> OnChat(string text)
{
    List<GeminiContent> contents = new()
    {
        GeminiContent.GetContent(text, GeminiRole.User),
    };
    
    GeminiChatResponse response;
    GeminiFunctionCall functionCall;
    do
    {
        response = await GeminiManager.Instance.Request<GeminiChatResponse>(
            new GeminiChatRequest(useBetaApi: true)
            {
                Contents = contents.ToArray(),
                Tools = new GeminiTool[] { _geminiFunctions },
                ToolConfig = GeminiToolConfiguration.GetConfiguration(GeminiFunctionCallingMode.Any),
            }
        );

        functionCall = response.Parts[0].FunctionCall;
        if (functionCall != null)
        {
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

            contents.Add(GeminiContent.GetContent(functionCall));
            contents.Add(GeminiContent.GetContent(functionCall.GetResponse(functionResponse)));
        }
    } while (functionCall != null);

    return response.Parts[0].Text;
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
The response is a JSON object, which is optional. Note the use of `GeminiToolConfiguration.GetConfiguration`, which is a utility method
to create a `GeminiToolConfiguration` with the given `GeminiFunctionCallingMode`. Here it is `GeminiFunctionCallingMode.Any`, which means
Gemini will always call at least one function in each conversation.

After the function is called, we respond by adding the call and response to the history. We use the `GetResponse` utility method to get a
`GeminiFunctionResponse` object with the response JSON.

Also, note that the request is using the beta API, as function calling is, as of writing, not available in the production API.

#### JSON Mode

In JSON mode, Gemini will always respond in a specified JSON response schema.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.Chat;
using Uralstech.UGemini.Schema;

public async Task<string> OnChat(string text)
{
    // Note: It seems GeminiManager.Gemini1_5Flash is not very good at JSON.
    GeminiChatResponse response = await GeminiManager.Instance.Request<GeminiChatResponse>(new GeminiChatRequest(GeminiManager.Gemini1_5Pro, true)
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

### File API

The Gemini File API can be used to store data on the cloud for future prompting with the Gemini models. The code for most of these requests is very simple.

#### Uploading Files 🚧
    
The package's code for this API method is unstable.

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.FileAPI;

public async void UploadFile(string text)
{
    GeminiFileUploadResponse response = await GeminiManager.Instance.Request<GeminiFileUploadResponse>(new GeminiFileUploadRequest(GeminiContentType.TextPlain.MimeType())
    {
        RawData = Encoding.UTF8.GetBytes(text)
    });
    
    Debug.Log($"Uploaded file: {FileToText(response.File)}");
}

// This method will be used in the examples multiple times.
private string FileToText(GeminiFile file)
{
    return $"{nameof(GeminiFile)}(\n" +
        $"\t{file.Name}\n" +
        $"\t{file.DisplayName}\n" +
        $"\t{file.MimeType}\n" +
        $"\t{file.SizeBytes}\n" +
        $"\t{file.CreateTime}\n" +
        $"\t{file.UpdateTime}\n" +
        $"\t{file.ExpirationTime}\n" +
        $"\t{file.Sha256Hash}\n" +
        $"\t{file.Uri}\n" +
        $"\t{file.State}\n" +
        $"\t{file.Status?.Message}\n" +
        $"\t{file.VideoMetadata?.VideoDuration}\n" +
        $")";
}
```

That's it! Convert your data to a byte array and just give the right MIME type as an argument!

#### Listing Available Files

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.FileAPI;

public async void ListFiles(int maxFiles = 10, string pageToken = string.Empty)
{
    GeminiFileListResponse response = await GeminiManager.Instance.Request<GeminiFileListResponse>(new GeminiFileListRequest()
    {
        MaxResponseFiles = maxFiles,
        PageToken = string.IsNullOrWhiteSpace(pageToken) ? string.Empty : pageToken,
    });

    Debug.Log($"Got file list response, next page token: {response?.NextPageToken}:");
    for (int i = 0; i < (response?.Files?.Length ?? 0); i++)
        Debug.Log($"File {i + 1}: {FileToText(response.Files[i])}");

    Debug.Log($"File list page completed.");
}
```

`maxFiles` is the total number of pages you want to retrieve in each request, and `pageToken` is the 'identifier' for the current page
in the multiple pages of file metadata. You can leave it empty to get the first page, and use `response.NextPageToken` as the token for
for the next page, and run the request again with it.

#### Retrieving a File

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.FileAPI;

public async void GetFile(string fileId)
{
    GeminiFile file = await GeminiManager.Instance.Request<GeminiFile>(new GeminiFileGetRequest(fileId));
    Debug.Log($"Got file: {FileToText(file)}");
}
```

Just put in the file's ID! You can get it from the `GeminiFile.Name` property, but remember to remove the "files/" prefix.

#### Deleting a File

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.FileAPI;

public async void DeleteFile(string fileId)
{
    await GeminiManager.Instance.Request(new GeminiFileDeleteRequest(fileId));
    Debug.Log("File deleted.");
}
```

Again, just put in the file's ID!

### Samples

For full-fledged examples of the features of this package, check out the samples in the Unity Package Manager.

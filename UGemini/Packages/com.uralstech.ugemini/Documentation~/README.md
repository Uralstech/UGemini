## UGemini Documentation

### Setup

Add an instance of `GeminiManager` to your scene, and set it up with your Gemini API key. You can get your API key from [*here*](https://makersuite.google.com/app/apikey).

### Coding

There are only two methods in `GeminiManager`:

| Method                                                                                    | What it does                          |
| -------------                                                                             | -------------                         |
| `void SetApiKey(string)`                                                                  | Sets the Gemini API key through code  |
| `Task<TResponse> Compute<TRequest, TResponse>(TRequest, RequestEndPoint, string, bool)`   | Computes a request on the Gemini API  |

All computations on the Gemini API are done through `GeminiManager.Compute`.

In this documentation, the fields and properties of each type will not be explained. Every type has been fully documented in code, so
please check the code docstrings to learn more about each type.

#### Beta API

`GeminiManager` supports both the `v1` and `v1beta` Gemini API versions. As a lot of features are still unsupported in the main `v1` API, you may
need to use the beta API. You can set the `useBeta` boolean parameter in the `Compute` method to do so.

#### Models

`GeminiManager` has four constant model IDs:

- `Gemini1_5Flash` - [*Gemini 1.5 Flash*](https://ai.google.dev/gemini-api/docs/models/gemini#gemini-1.5-flash)

- `Gemini1_5Pro` - [*Gemini 1.5 Pro*](https://ai.google.dev/gemini-api/docs/models/gemini#gemini-1.5-pro)

- `Gemini1_0Pro` - [*Gemini 1.0 Pro*](https://ai.google.dev/gemini-api/docs/models/gemini#gemini-1.0-pro)

- `Gemini1_0ProVision` - [*Gemini 1.0 Pro Vision*](https://ai.google.dev/gemini-api/docs/models/gemini#gemini-1.0-pro-vision)
    - Gemini 1.0 Pro Vision is deprecated. Use Use 1.5 Flash (`Gemini1_5Flash`) or 1.5 Pro (`Gemini1_5Pro`) instead.


By default, the `Compute` method uses the [*Gemini 1.5 Flash*](https://ai.google.dev/gemini-api/docs/models/gemini#gemini-1.5-flash)
model for all requests. This can be changed by either providing a string ID or one of the constants to the `model` parameter in the `Compute` method.

#### Simple GenerateContent (Chat) Request

This is a simple request that asks Gemini a question and logs the response to the console.

```csharp
using Uralstech.UGemini.Chat;

async void QueryGemini()
{
    string text = "Hello! How are you doing?";
    GeminiChatResponse response = await GeminiManager.Instance.Compute<GeminiChatRequest, GeminiChatResponse>(
        new GeminiChatRequest()
        {
            Contents = new GeminiContent[]
            {
                GeminiContent.GetContent(text, GeminiRole.User),
            },
        },
        GeminiManager.RequestEndPoint.Chat
    );

    Debug.Log(response.Parts[0].Text);
}
```

That's all! We specify that we are executing a request of type `GeminiChatRequest`, and that we expect a response of type `GeminiChatResponse`,
then we specified the content of the request and the endpoint we want to execute it on, `GeminiManager.RequestEndPoint.Chat`! And voilà, we've
got the response in `response.Parts[0].Text`!

Right now, there are two types of requests and endpoints that are supported:

- `GeminiChatRequest` | `GeminiChatResponse`:
    - Available in the `Uralstech.UGemini.Chat` namespace
    - Meant to run on the `GeminiManager.RequestEndPoint.Chat` endpoint
    - Runs a `generateContent` request on the given model

and

- `GeminiTokenCountRequest` | `GeminiTokenCountResponse`:
    - Available in the `Uralstech.UGemini.TokenCounting` namespace
    - Meant to run on the `GeminiManager.RequestEndPoint.CountTokens` endpoint
    - Counts the number of tokens in the given request contents for the given model

#### Multi-turn Chat Request

This is a simple method that maintains the user's chat history with Gemini.

```csharp
using Uralstech.UGemini.Chat;

List<GeminiContent> _chatHistory = new();

async Task<string> OnChat(string text)
{
    _chatHistory.Add(GeminiContent.GetContent(text, GeminiRole.User));
    GeminiChatRequest request = new()
    {
        Contents = _chatHistory.ToArray(),
    };

    GeminiChatResponse response = await GeminiManager.Instance.Compute<GeminiChatRequest, GeminiChatResponse>(request, GeminiManager.RequestEndPoint.Chat);
    
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
using Uralstech.UGemini.Chat;

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
    - Can convert `string` messages, `Texture2D` images and *`AudioClip` audio to `GeminiContent` objects.

- `GeminiContentBlob.GetContentBlob`
    - Can convert `Texture2D` images and *`AudioClip` audio to `GeminiContentBlob` objects.

*Requires [*Utilities.Encoding.Wav*](https://openupm.com/packages/com.utilities.encoder.wav/).

#### Function Calling

First, we have to setup our tools and define our function schemas.

```csharp
using Uralstech.UGemini.Chat;
using Uralstech.UGemini.Schema;
using Uralstech.UGemini.Tools;
using Uralstech.UGemini.Tools.Declaration;

GeminiTool s_geminiFunctions = new GeminiTool()
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
        response = await GeminiManager.Instance.Compute<GeminiChatRequest, GeminiChatResponse>(new GeminiChatRequest()
        {
            Contents = contents.ToArray(),
            Tools = new GeminiTool[] { s_geminiFunctions },
            ToolConfig = GeminiToolConfiguration.GetConfiguration(GeminiFunctionCallingMode.Any),
        }, GeminiManager.RequestEndPoint.Chat, useBeta: true);

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
public async Task<string> OnChat(string text)
{
    // Note: It seems GeminiManager.Gemini1_5Flash is not very good at JSON.
    GeminiChatResponse response = await GeminiManager.Instance.Compute<GeminiChatRequest, GeminiChatResponse>(new GeminiChatRequest()
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
    }, GeminiManager.RequestEndPoint.Chat, GeminiManager.Gemini1_5Pro, true);

    return response.Parts[0].Text;
}
```

Here, we used a schema for an array of objects, which contain two parameters: `expression` and `explanation`.
We have told Gemini to split the response into the parameters, where a mathematical expression and its explanation is given.

The `GeminiSchema` object is the same type used for function calling.

### Samples

For full-fledged examples of the features of this package, check out the samples in the Unity Package Manager.
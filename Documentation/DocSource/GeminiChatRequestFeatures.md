# GeminiChatRequest Features

`GeminiAnswerRequest` also shares some of these features.

## Streaming Responses

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

## Adding Media Content to Requests

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

### Utility Methods

`GeminiContent` and `GeminiContentBlob` also contain static utility methods to help
create them from Unity types like `AudioClip` or `Texture2D`:

- `GeminiContent.GetContent`
    - Can convert `string` messages, `Texture2D` images, `AudioClip`\* audio and `GeminiFile` data to `GeminiContent` objects.

- `GeminiContentBlob.GetContentBlob`
    - Can convert `Texture2D` images and `AudioClip`\* audio to `GeminiContentBlob` objects.

\*Requires [*Utilities.Encoding.Wav*](https://openupm.com/packages/com.utilities.encoder.wav/).

## Function Calling

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

To use Gemini Tools, we need to declare each tool to use. So, we have created a declaration for function calling.
Each *tool* must be declared separately but every *function* must be declared in a single *tool* declaration.

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
            ToolConfig = GeminiToolConfiguration.GetConfiguration(GeminiFunctionCallingMode.Auto),
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
which is a utility method to create a `GeminiToolConfiguration` with the given `GeminiFunctionCallingMode`. `GeminiFunctionCallingMode.Any`
means Gemini will always call at least one function in each *request*, `Auto` means the model will call the functions when it thinks it needs
to, and `None` means no functions can be called.

After the function is called, we respond by adding the calls and responses to the history. We use the `GetResponse` utility method to get a
`GeminiFunctionResponse` object with the response JSON.

Function calling is, as of writing, only available in the Beta API.

## Code Execution

Code execution is also a Tool, so it is similar to function calling:

```csharp
using Uralstech.UGemini;
using Uralstech.UGemini.Models;
using Uralstech.UGemini.Models.Content;
using Uralstech.UGemini.Models.Generation.Chat;
using Uralstech.UGemini.Models.Generation.Tools.Declaration;

private GeminiTool _geminiCodeExecution = new GeminiTool()
{
    CodeExecution = new GeminiCodeExecution()
};

[SerializeField] private Text _chatResponse;

private async Task<string> OnChat(string text)
{
    List<GeminiContent> contents = new()
    {
        GeminiContent.GetContent(text, GeminiRole.User),
    };

    GeminiChatResponse response = await GeminiManager.Instance.Request<GeminiChatResponse>(new GeminiChatRequest(GeminiModel.Gemini1_5Flash, true)
    {
        Contents = contents.ToArray(),
        Tools = new GeminiTool[] { _geminiCodeExecution },
    });

    string responseText = string.Join(", ", Array.ConvertAll(response.Parts, part => $"(Text={part.Text}, Code={part.ExecutableCode?.Code}, ExecutionResult={part.CodeExecutionResult?.Output})"));

    _chatResponse.text = responseText;
    return responseText;
}
```

That's it! Now, when code execution is used, the response should be something like this:

```
> Make a simple python program to print hello world and use code execution for that.
Result: (Text=, Code=, ExecutionResult=), (Text=, Code=print("Hello world!"), ExecutionResult=), (Text=, Code=, ExecutionResult=Hello world!),
(Text=I have created a simple Python program that prints "Hello world!".  I used the `print()` function to achieve this. The code was executed
using the `tool_code` block., Code=, ExecutionResult=)
```

Code execution is also, as of writing, only available in the Beta API.

## JSON Response Mode

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
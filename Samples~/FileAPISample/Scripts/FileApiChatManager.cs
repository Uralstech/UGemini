using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Uralstech.UGemini;
using Uralstech.UGemini.FileAPI;
using Uralstech.UGemini.Models;
using Uralstech.UGemini.Models.Content;
using Uralstech.UGemini.Models.Generation.Chat;

public class FileApiChatManager : MonoBehaviour
{
    [Header("File API")]
    [SerializeField] private InputField _fileContentInput;
    [SerializeField] private InputField _fileDisplayNameInput;
    [SerializeField] private InputField _fileIdInput;
    [SerializeField] private InputField _maxFileListInput;
    [SerializeField] private InputField _fileListTokenInput;

    [Header("Prompting")]
    [SerializeField] private InputField _promptInput;
    [SerializeField] private InputField _promptFileIdInput;
    [SerializeField] private Text _responseText;

    public async void OnUploadFile()
    {
        string text = _fileContentInput.text;
        if (string.IsNullOrWhiteSpace(text))
        {
            Debug.LogError("File content should not be null or whitespace!");
            return;
        }

        GeminiFileUploadResponse response = await GeminiManager.Instance.Request<GeminiFileUploadResponse>(new GeminiFileUploadRequest(GeminiContentType.TextPlain.MimeType())
        {
            File = new GeminiFileUploadMetaData()
            {
                DisplayName = string.IsNullOrEmpty(_fileDisplayNameInput.text) ? null : _fileDisplayNameInput.text,
            },
            RawData = Encoding.UTF8.GetBytes(text)
        });

        Debug.Log($"Uploaded file: {FileToText(response.File)}");
    }

    public async void OnGetFile()
    {
        string text = _fileIdInput.text;
        if (string.IsNullOrWhiteSpace(text))
        {
            Debug.LogError("File ID should not be null or whitespace!");
            return;
        }

        GeminiFile file = await GeminiManager.Instance.Request<GeminiFile>(new GeminiFileGetRequest(text));
        Debug.Log($"Got file: {FileToText(file)}");
    }

    public async void OnDeleteFile()
    {
        string text = _fileIdInput.text;
        if (string.IsNullOrWhiteSpace(text))
        {
            Debug.LogError("File ID should not be null or whitespace!");
            return;
        }

        await GeminiManager.Instance.Request(new GeminiFileDeleteRequest(text));
        Debug.Log("File deleted.");
    }

    public async void OnListFiles()
    {
        string maxFiles = _maxFileListInput.text;
        string token = _fileListTokenInput.text;

        GeminiFileListResponse response = await GeminiManager.Instance.Request<GeminiFileListResponse>(new GeminiFileListRequest()
        {
            MaxResponseFiles = string.IsNullOrWhiteSpace(maxFiles) ? 10 : int.Parse(maxFiles),
            PageToken = string.IsNullOrWhiteSpace(token) ? string.Empty : token,
        });

        Debug.Log($"Got file list response, next page token: {response?.NextPageToken}:");
        for (int i = 0; i < (response?.Files?.Length ?? 0); i++)
            Debug.Log($"File {i + 1}: {FileToText(response.Files[i])}");

        Debug.Log($"File list page completed.");
    }

    public async void OnChatWithFile()
    {
        string promptFile = _promptFileIdInput.text;
        if (string.IsNullOrWhiteSpace(promptFile))
        {
            Debug.LogError("File ID should not be null or whitespace!");
            return;
        }

        string prompt = _promptInput.text;
        if (string.IsNullOrWhiteSpace(prompt))
        {
            Debug.LogError("Prompt should not be null or whitespace!");
            return;
        }

        GeminiFile file = await GeminiManager.Instance.Request<GeminiFile>(new GeminiFileGetRequest(promptFile));
        GeminiChatResponse response = await GeminiManager.Instance.Request<GeminiChatResponse>(new GeminiChatRequest(GeminiModel.Gemini1_5Flash, true)
        {
            Contents = new GeminiContent[]
            {
                GeminiContent.GetContent(prompt, file, GeminiRole.User)
            }
        });

        _responseText.text = response.Parts[0].Text;
    }

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
}

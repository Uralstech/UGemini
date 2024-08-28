using UnityEngine;
using UnityEngine.UI;
using Uralstech.UGemini;
using Uralstech.UGemini.Models;
using Uralstech.UGemini.Models.Content;
using Uralstech.UGemini.Models.Generation.Chat;

public class ModelMetadataRetrievalManager : MonoBehaviour
{
    [SerializeField] private bool _useBetaApi;

    [Header("Models Get/List API")]
    [SerializeField] private InputField _modelIdInput;
    [SerializeField] private InputField _maxModelListInput;
    [SerializeField] private InputField _modelListTokenInput;

    [Header("Prompting")]
    [SerializeField] private InputField _promptInput;
    [SerializeField] private InputField _promptModelIdInput;
    [SerializeField] private Text _responseText;

    public async void OnGetModel()
    {
        string text = _modelIdInput.text;
        if (string.IsNullOrWhiteSpace(text))
        {
            Debug.LogError("Model ID should not be null or whitespace!");
            return;
        }

        GeminiModel model = await GeminiManager.Instance.Request<GeminiModel>(new GeminiModelGetRequest(text, _useBetaApi));
        Debug.Log($"Got model: {ModelToText(model)}");
    }

    public async void OnListModels()
    {
        string maxModels = _maxModelListInput.text;
        string token = _modelListTokenInput.text;

        GeminiModelListResponse response = await GeminiManager.Instance.Request<GeminiModelListResponse>(new GeminiModelListRequest(_useBetaApi)
        {
            MaxResponseModels = string.IsNullOrWhiteSpace(maxModels) ? 50 : int.Parse(maxModels),
            PageToken = string.IsNullOrWhiteSpace(token) ? string.Empty : token,
        });

        Debug.Log($"Got model list response, next page token: {response?.NextPageToken}:");
        for (int i = 0; i < (response?.Models?.Length ?? 0); i++)
            Debug.Log($"Model {i + 1}: {ModelToText(response.Models[i])}");

        Debug.Log($"Model list page completed.");
    }

    public async void OnChatWithModel()
    {
        string promptModel = _promptModelIdInput.text;
        if (string.IsNullOrWhiteSpace(promptModel))
        {
            Debug.LogError("Model ID should not be null or whitespace!");
            return;
        }

        string prompt = _promptInput.text;
        if (string.IsNullOrWhiteSpace(prompt))
        {
            Debug.LogError("Prompt should not be null or whitespace!");
            return;
        }

        GeminiModel model = await GeminiManager.Instance.Request<GeminiModel>(new GeminiModelGetRequest(promptModel, _useBetaApi));
        GeminiChatResponse response = await GeminiManager.Instance.Request<GeminiChatResponse>(new GeminiChatRequest(model, _useBetaApi)
        {
            Contents = new GeminiContent[]
            {
                GeminiContent.GetContent(prompt, GeminiRole.User)
            }
        });

        _responseText.text = response.Parts[0].Text;
    }

    private string ModelToText(GeminiModel model)
    {
        return $"{nameof(GeminiModel)}(\n" +
            $"\t{model.Name}\n" +
            $"\t{model.BaseModelId}\n" +
            $"\t{model.Version}\n" +
            $"\t{model.DisplayName}\n" +
            $"\t{model.Description}\n" +
            $"\t{model.InputTokenLimit}\n" +
            $"\t{model.OutputTokenLimit}\n" +
            $"\t{string.Join(',', model.SupportedGenerationMethods)}\n" +
            $"\t{model.Temperature}\n" +
            $"\t{model.TopP}\n" +
            $"\t{model.TopK}\n" +
            $")";
    }
}

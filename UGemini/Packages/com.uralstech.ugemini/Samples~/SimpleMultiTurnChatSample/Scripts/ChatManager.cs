using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Uralstech.UGemini;
using Uralstech.UGemini.Chat;

public class ChatManager : MonoBehaviour
{
    [SerializeField] private bool _useBeta = true;
    [SerializeField] private InputField _chatInput;
    [SerializeField] private Transform _chatMessages;
    [SerializeField] private UIChatMessage _chatMessagePrefab;

    private readonly List<GeminiContent> _chatHistory = new();
    private GeminiContent _systemPrompt = null;

    private GeminiRole _senderRole = GeminiRole.User;
    private bool _settingSystemPrompt = false;

    public void SetRole(int role)
    {
        if (role > (int)GeminiRole.ToolResponse)
        {
            _settingSystemPrompt |= true;
            return;
        }

        _senderRole = (GeminiRole)role;
    }

    public async void OnChat()
    {
        string text = _chatInput.text;
        if (string.IsNullOrWhiteSpace(text))
        {
            Debug.LogError("Chat text should not be null or whitespace!");
            return;
        }

        _chatInput.text = string.Empty;
        GeminiContent addedContent;

        if (_settingSystemPrompt)
        {
            if (!_useBeta)
            {
                Debug.LogError("System prompts are not yet supported in the non-beta API!");
                return;
            }

            addedContent = _systemPrompt = GeminiContent.GetNew(text);
        }
        else
            _chatHistory.Add(addedContent = GeminiContent.GetNew(text, _senderRole));
       
        AddMessage(addedContent, _settingSystemPrompt);
        _settingSystemPrompt = false;
        if (_chatHistory.Count == 0)
            return;

        GeminiChatRequest request = new()
        {
            Contents = _chatHistory.ToArray(),
            SystemInstruction = _systemPrompt,
        };

        GeminiChatResponse response = await GeminiManager.Instance.Compute<GeminiChatRequest, GeminiChatResponse>(request, GeminiManager.RequestEndPoint.Chat, useBeta: _useBeta);
        AddMessage(response.Candidates[0].Content);
    }

    private void AddMessage(GeminiContent content, bool isSystemPrompt = false)
    {
        UIChatMessage message = Instantiate(_chatMessagePrefab, _chatMessages); ;
        message.Setup(content, isSystemPrompt);
    }
}

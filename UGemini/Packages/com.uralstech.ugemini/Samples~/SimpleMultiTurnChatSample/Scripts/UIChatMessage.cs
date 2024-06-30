using System;
using UnityEngine;
using UnityEngine.UI;
using Uralstech.UGemini;

public class UIChatMessage : MonoBehaviour
{
    [SerializeField] private Text _senderText;
    [SerializeField] private Text _messageText;
    [SerializeField] private RawImage _messageImage;

    public void Setup(GeminiContent content, bool isSystemPrompt)
    {
        Texture2D image = new(1, 1);
        foreach (GeminiContentPart part in content.Parts)
        {
            if (part.Text != null)
                _messageText.text = part.Text;
            else if (part.InlineData != null)
            {
                switch (part.InlineData.MimeType)
                {
                    case GeminiContentType.ImagePNG:
                    case GeminiContentType.ImageJPEG:
                        image.LoadImage(Convert.FromBase64String(part.InlineData.Data));
                        break;

                    default:
                        Debug.LogError($"Could not load image of type: {part.InlineData.MimeType}!");
                        break;
                }
            }
        }

        _senderText.text = isSystemPrompt ? "System" : content.Role.ToString();
    }
}

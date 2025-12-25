using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace WiseCrab44.Avalonia.Lib.Controls;

/// <summary>
/// 프롬프트 입력을 위한 커스텀 컨트롤 (클라우드 업로드 버튼 + 텍스트 입력 + 전송 버튼)
/// A custom control for prompt input with cloud upload button, text input, and send button.
/// </summary>
public sealed class PromptInputBox : TemplatedControl
{
    public static readonly StyledProperty<string?> TextProperty =
        AvaloniaProperty.Register<PromptInputBox, string?>(nameof(Text));

    public static readonly StyledProperty<string?> PlaceholderProperty =
        AvaloniaProperty.Register<PromptInputBox, string?>(nameof(Placeholder), "Enter your prompt...");

    public string? Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public string? Placeholder
    {
        get => GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }
}

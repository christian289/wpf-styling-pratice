using Avalonia;
using Avalonia.Controls.Primitives;

namespace WisePanda94.Avalonia.Lib.Controls;

/// <summary>
/// Send Message 버튼 커스텀 컨트롤
/// Hover 시 scale 애니메이션이 적용되는 Material Design 스타일 버튼
/// </summary>
public sealed class SendMessageButton : TemplatedControl
{
    /// <summary>
    /// 버튼에 표시할 텍스트
    /// </summary>
    public static readonly StyledProperty<string> TextProperty =
        AvaloniaProperty.Register<SendMessageButton, string>(nameof(Text), "Send Message");

    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
}

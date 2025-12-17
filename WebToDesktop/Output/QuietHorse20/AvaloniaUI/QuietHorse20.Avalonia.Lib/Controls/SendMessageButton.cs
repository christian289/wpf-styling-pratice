using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace QuietHorse20.Avalonia.Lib.Controls;

/// <summary>
/// 종이 비행기 아이콘이 포함된 Send Message 버튼 컨트롤.
/// A Send Message button control with a paper plane icon.
/// </summary>
public sealed class SendMessageButton : TemplatedControl
{
    /// <summary>
    /// 버튼에 표시되는 텍스트를 정의합니다.
    /// Defines the text displayed on the button.
    /// </summary>
    public static readonly StyledProperty<string> TextProperty =
        AvaloniaProperty.Register<SendMessageButton, string>(nameof(Text), "Send Message");

    /// <summary>
    /// 버튼에 표시되는 텍스트를 가져오거나 설정합니다.
    /// Gets or sets the text displayed on the button.
    /// </summary>
    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
}

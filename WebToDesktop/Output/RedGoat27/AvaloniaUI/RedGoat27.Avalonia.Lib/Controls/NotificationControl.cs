using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace RedGoat27.Avalonia.Lib.Controls;

/// <summary>
/// 트로피 아이콘과 축하 메시지를 표시하는 알림 컨트롤
/// A notification control that displays a trophy icon with congratulation messages
/// </summary>
public sealed class NotificationControl : TemplatedControl
{
    public static readonly StyledProperty<string> TitleProperty =
        AvaloniaProperty.Register<NotificationControl, string>(nameof(Title), "Congratulations!");

    public static readonly StyledProperty<string> MessageProperty =
        AvaloniaProperty.Register<NotificationControl, string>(nameof(Message), "You reached level 10!");

    /// <summary>
    /// 제목 텍스트
    /// Title text
    /// </summary>
    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    /// <summary>
    /// 메시지 텍스트
    /// Message text
    /// </summary>
    public string Message
    {
        get => GetValue(MessageProperty);
        set => SetValue(MessageProperty, value);
    }
}

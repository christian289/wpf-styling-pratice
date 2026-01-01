using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace FuzzyFly47.Avalonia.Lib.Controls;

/// <summary>
/// 게임 레벨업 알림 커스텀 컨트롤
/// Game level-up notification custom control
/// </summary>
public sealed class LevelNotification : TemplatedControl
{
    /// <summary>
    /// 알림 메시지 (예: "Congratulations Champion!")
    /// Notification message (e.g., "Congratulations Champion!")
    /// </summary>
    public static readonly StyledProperty<string> MessageProperty =
        AvaloniaProperty.Register<LevelNotification, string>(nameof(Message), "Congratulations Champion!");

    /// <summary>
    /// 레벨 텍스트 (예: "Level 10")
    /// Level text (e.g., "Level 10")
    /// </summary>
    public static readonly StyledProperty<string> LevelTextProperty =
        AvaloniaProperty.Register<LevelNotification, string>(nameof(LevelText), "Level 10");

    public string Message
    {
        get => GetValue(MessageProperty);
        set => SetValue(MessageProperty, value);
    }

    public string LevelText
    {
        get => GetValue(LevelTextProperty);
        set => SetValue(LevelTextProperty, value);
    }
}

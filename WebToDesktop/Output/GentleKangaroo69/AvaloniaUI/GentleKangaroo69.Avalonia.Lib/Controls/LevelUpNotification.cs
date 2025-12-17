using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace GentleKangaroo69.Avalonia.Lib.Controls;

/// <summary>
/// "LEVEL UP!" 알림 컨트롤 - bounce 애니메이션과 hover 효과가 있는 알림
/// "LEVEL UP!" notification control with bounce animation and hover effects
/// </summary>
public sealed class LevelUpNotification : TemplatedControl
{
    /// <summary>
    /// 알림 텍스트를 정의합니다.
    /// Defines the notification text.
    /// </summary>
    public static readonly StyledProperty<string> TextProperty =
        AvaloniaProperty.Register<LevelUpNotification, string>(nameof(Text), "LEVEL UP!");

    /// <summary>
    /// 알림 텍스트
    /// Notification text
    /// </summary>
    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
}

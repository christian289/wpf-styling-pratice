using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace TastyApe73.Avalonia.Lib.Controls;

/// <summary>
/// Level Up 알림과 confetti 애니메이션을 표시하는 커스텀 컨트롤
/// A custom control that displays Level Up notification with confetti animation
/// </summary>
public sealed class LevelUpNotification : TemplatedControl
{
    /// <summary>
    /// 알림에 표시할 텍스트
    /// Text to display in the notification
    /// </summary>
    public static readonly StyledProperty<string> TextProperty =
        AvaloniaProperty.Register<LevelUpNotification, string>(nameof(Text), "Level Up!");

    /// <summary>
    /// confetti 애니메이션 활성화 여부
    /// Whether confetti animation is enabled
    /// </summary>
    public static readonly StyledProperty<bool> IsConfettiEnabledProperty =
        AvaloniaProperty.Register<LevelUpNotification, bool>(nameof(IsConfettiEnabled), true);

    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public bool IsConfettiEnabled
    {
        get => GetValue(IsConfettiEnabledProperty);
        set => SetValue(IsConfettiEnabledProperty, value);
    }
}

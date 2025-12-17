using System.Windows;
using System.Windows.Controls;

namespace TastyApe73.Wpf.UI.Controls;

/// <summary>
/// "Level Up!" 알림 컨트롤 (컨페티 애니메이션 포함)
/// "Level Up!" notification control with confetti animation
/// </summary>
public sealed class TastyApe73 : ContentControl
{
    /// <summary>
    /// 알림 텍스트
    /// Notification text
    /// </summary>
    public static readonly DependencyProperty NotificationTextProperty =
        DependencyProperty.Register(
            nameof(NotificationText),
            typeof(string),
            typeof(TastyApe73),
            new PropertyMetadata("Level Up!"));

    /// <summary>
    /// 컨페티 표시 여부
    /// Whether to show confetti
    /// </summary>
    public static readonly DependencyProperty ShowConfettiProperty =
        DependencyProperty.Register(
            nameof(ShowConfetti),
            typeof(bool),
            typeof(TastyApe73),
            new PropertyMetadata(true));

    static TastyApe73()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(TastyApe73),
            new FrameworkPropertyMetadata(typeof(TastyApe73)));
    }

    public string NotificationText
    {
        get => (string)GetValue(NotificationTextProperty);
        set => SetValue(NotificationTextProperty, value);
    }

    public bool ShowConfetti
    {
        get => (bool)GetValue(ShowConfettiProperty);
        set => SetValue(ShowConfettiProperty, value);
    }
}

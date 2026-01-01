using System.Windows;
using System.Windows.Controls;

namespace FuzzyFly47.Wpf.UI.Controls;

/// <summary>
/// Notification 스타일 컨트롤 - 레벨업 알림 표시
/// Notification style control - Level up notification display
/// </summary>
public sealed class FuzzyFly47 : Control
{
    static FuzzyFly47()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(FuzzyFly47),
            new FrameworkPropertyMetadata(typeof(FuzzyFly47)));
    }

    /// <summary>
    /// 알림 메시지
    /// Notification message
    /// </summary>
    public static readonly DependencyProperty MessageProperty =
        DependencyProperty.Register(
            nameof(Message),
            typeof(string),
            typeof(FuzzyFly47),
            new PropertyMetadata("Congratulations Champion!"));

    public string Message
    {
        get => (string)GetValue(MessageProperty);
        set => SetValue(MessageProperty, value);
    }

    /// <summary>
    /// 레벨 텍스트
    /// Level text
    /// </summary>
    public static readonly DependencyProperty LevelTextProperty =
        DependencyProperty.Register(
            nameof(LevelText),
            typeof(string),
            typeof(FuzzyFly47),
            new PropertyMetadata("Level 10"));

    public string LevelText
    {
        get => (string)GetValue(LevelTextProperty);
        set => SetValue(LevelTextProperty, value);
    }
}

using System.Windows;
using System.Windows.Controls;

namespace RedGoat27.Wpf.UI.Controls;

/// <summary>
/// 축하 알림을 표시하는 Notification 컨트롤.
/// 트로피 아이콘과 메시지를 표시하며 bounce/spin 애니메이션을 지원합니다.
/// A Notification control that displays congratulation messages.
/// Shows a trophy icon with message and supports bounce/spin animations.
/// </summary>
public sealed class RedGoat27 : Control
{
    static RedGoat27()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(RedGoat27),
            new FrameworkPropertyMetadata(typeof(RedGoat27)));
    }

    /// <summary>
    /// 메인 타이틀 텍스트 (예: "Congratulations!")
    /// Main title text (e.g., "Congratulations!")
    /// </summary>
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(
            nameof(Title),
            typeof(string),
            typeof(RedGoat27),
            new PropertyMetadata("Congratulations!"));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    /// <summary>
    /// 서브 메시지 텍스트 (예: "You reached level 10!")
    /// Sub message text (e.g., "You reached level 10!")
    /// </summary>
    public static readonly DependencyProperty MessageProperty =
        DependencyProperty.Register(
            nameof(Message),
            typeof(string),
            typeof(RedGoat27),
            new PropertyMetadata("You reached level 10!"));

    public string Message
    {
        get => (string)GetValue(MessageProperty);
        set => SetValue(MessageProperty, value);
    }
}

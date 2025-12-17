using System.Windows;
using System.Windows.Controls;

namespace GentleKangaroo69.Wpf.UI.Controls;

/// <summary>
/// "LEVEL UP!" 알림 스타일 커스텀 컨트롤
/// "LEVEL UP!" notification style custom control
/// </summary>
public sealed class GentleKangaroo69 : ContentControl
{
    static GentleKangaroo69()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(GentleKangaroo69),
            new FrameworkPropertyMetadata(typeof(GentleKangaroo69)));
    }

    /// <summary>
    /// 알림 텍스트
    /// Notification text
    /// </summary>
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(
            nameof(Text),
            typeof(string),
            typeof(GentleKangaroo69),
            new PropertyMetadata("LEVEL UP!"));

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
}

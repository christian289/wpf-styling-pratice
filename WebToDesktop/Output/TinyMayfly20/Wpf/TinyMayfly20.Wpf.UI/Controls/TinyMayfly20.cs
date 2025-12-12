using System.Windows;
using System.Windows.Controls;

namespace TinyMayfly20.Wpf.UI.Controls;

/// <summary>
/// 게임 스타일의 픽셀 아트 알림 컨트롤
/// Game-style pixel art notification control
/// </summary>
public sealed class TinyMayfly20 : Control
{
    static TinyMayfly20()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(TinyMayfly20),
            new FrameworkPropertyMetadata(typeof(TinyMayfly20)));
    }

    /// <summary>
    /// 타이틀 텍스트 (기본값: "Level up!")
    /// Title text (default: "Level up!")
    /// </summary>
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(
            nameof(Title),
            typeof(string),
            typeof(TinyMayfly20),
            new PropertyMetadata("Level up!"));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    /// <summary>
    /// 서브타이틀 텍스트 (기본값: "Your power:")
    /// Subtitle text (default: "Your power:")
    /// </summary>
    public static readonly DependencyProperty SubtitleProperty =
        DependencyProperty.Register(
            nameof(Subtitle),
            typeof(string),
            typeof(TinyMayfly20),
            new PropertyMetadata("Your power:"));

    public string Subtitle
    {
        get => (string)GetValue(SubtitleProperty);
        set => SetValue(SubtitleProperty, value);
    }

    /// <summary>
    /// 파워 값 텍스트 (기본값: "+8000!")
    /// Power value text (default: "+8000!")
    /// </summary>
    public static readonly DependencyProperty PowerValueProperty =
        DependencyProperty.Register(
            nameof(PowerValue),
            typeof(string),
            typeof(TinyMayfly20),
            new PropertyMetadata("+8000!"));

    public string PowerValue
    {
        get => (string)GetValue(PowerValueProperty);
        set => SetValue(PowerValueProperty, value);
    }
}

using System.Windows;
using System.Windows.Controls;

namespace BitterWolverine27.Wpf.UI.Controls;

/// <summary>
/// 호버 시 팝업되는 Tooltip을 가진 컨트롤
/// Tooltip control that pops up on hover
/// </summary>
public sealed class BitterWolverine27 : ContentControl
{
    /// <summary>
    /// Tooltip에 표시될 텍스트
    /// Text to display in the tooltip
    /// </summary>
    public static readonly DependencyProperty TooltipTextProperty =
        DependencyProperty.Register(
            nameof(TooltipText),
            typeof(string),
            typeof(BitterWolverine27),
            new PropertyMetadata("Heyy\ud83d\udc4b"));

    /// <summary>
    /// 메인 텍스트 (호버 영역)
    /// Main text (hover area)
    /// </summary>
    public static readonly DependencyProperty HoverTextProperty =
        DependencyProperty.Register(
            nameof(HoverText),
            typeof(string),
            typeof(BitterWolverine27),
            new PropertyMetadata("Hover me !"));

    public string TooltipText
    {
        get => (string)GetValue(TooltipTextProperty);
        set => SetValue(TooltipTextProperty, value);
    }

    public string HoverText
    {
        get => (string)GetValue(HoverTextProperty);
        set => SetValue(HoverTextProperty, value);
    }

    static BitterWolverine27()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(BitterWolverine27),
            new FrameworkPropertyMetadata(typeof(BitterWolverine27)));
    }
}

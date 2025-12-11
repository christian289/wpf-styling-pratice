using System.Windows;
using System.Windows.Controls;

namespace SpottyZebra83.Wpf.UI.Controls;

/// <summary>
/// Tooltip 스타일 버튼 컨트롤. 호버 시 툴팁이 표시되고 내부 텍스트가 전환되는 애니메이션 효과를 제공합니다.
/// Tooltip-style button control that displays a tooltip on hover with animated text transitions.
/// </summary>
public sealed class SpottyZebra83 : ContentControl
{
    /// <summary>
    /// 툴팁에 표시될 텍스트
    /// Text to be displayed in the tooltip
    /// </summary>
    public static readonly DependencyProperty TooltipTextProperty =
        DependencyProperty.Register(
            nameof(TooltipText),
            typeof(string),
            typeof(SpottyZebra83),
            new PropertyMetadata("Uiverse.io"));

    /// <summary>
    /// 호버 시 표시될 텍스트
    /// Text to be displayed on hover
    /// </summary>
    public static readonly DependencyProperty HoverTextProperty =
        DependencyProperty.Register(
            nameof(HoverText),
            typeof(string),
            typeof(SpottyZebra83),
            new PropertyMetadata("Hello! 👋"));

    static SpottyZebra83()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(SpottyZebra83),
            new FrameworkPropertyMetadata(typeof(SpottyZebra83)));
    }

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
}

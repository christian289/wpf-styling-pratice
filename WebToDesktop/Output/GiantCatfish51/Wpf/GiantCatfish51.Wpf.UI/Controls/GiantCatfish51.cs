using System.Windows;
using System.Windows.Controls;

namespace GiantCatfish51.Wpf.UI.Controls;

/// <summary>
/// Tooltip 스타일 버튼 컨트롤.
/// Hover 시 상단에 말풍선 형태의 툴팁이 나타납니다.
/// Tooltip-style button control.
/// Shows a speech bubble tooltip above when hovered.
/// </summary>
public sealed class GiantCatfish51 : ContentControl
{
    /// <summary>
    /// 툴팁에 표시할 텍스트.
    /// Text to display in the tooltip.
    /// </summary>
    public static readonly DependencyProperty TooltipTextProperty =
        DependencyProperty.Register(
            nameof(TooltipText),
            typeof(string),
            typeof(GiantCatfish51),
            new PropertyMetadata("Tooltip"));

    static GiantCatfish51()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(GiantCatfish51),
            new FrameworkPropertyMetadata(typeof(GiantCatfish51)));
    }

    public string TooltipText
    {
        get => (string)GetValue(TooltipTextProperty);
        set => SetValue(TooltipTextProperty, value);
    }
}

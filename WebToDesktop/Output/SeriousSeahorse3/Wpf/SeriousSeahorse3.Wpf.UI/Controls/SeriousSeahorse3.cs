using System.Windows;
using System.Windows.Controls;

namespace SeriousSeahorse3.Wpf.UI.Controls;

/// <summary>
/// 마우스 오버 시 상단에 Tooltip을 표시하는 버튼 컨트롤
/// A button control that displays a tooltip above on mouse hover
/// </summary>
public sealed class SeriousSeahorse3 : Button
{
    static SeriousSeahorse3()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(SeriousSeahorse3),
            new FrameworkPropertyMetadata(typeof(SeriousSeahorse3)));
    }

    /// <summary>
    /// Tooltip에 표시될 텍스트
    /// Text to be displayed in the tooltip
    /// </summary>
    public static readonly DependencyProperty TooltipTextProperty =
        DependencyProperty.Register(
            nameof(TooltipText),
            typeof(string),
            typeof(SeriousSeahorse3),
            new PropertyMetadata("👋🏻👽 Hi!"));

    public string TooltipText
    {
        get => (string)GetValue(TooltipTextProperty);
        set => SetValue(TooltipTextProperty, value);
    }
}

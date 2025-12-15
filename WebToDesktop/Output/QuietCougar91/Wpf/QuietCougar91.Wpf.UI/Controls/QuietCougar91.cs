using System.Windows;
using System.Windows.Controls;

namespace QuietCougar91.Wpf.UI.Controls;

/// <summary>
/// 호버 시 위로 올라오는 애니메이션 툴팁 버튼 컨트롤
/// Animated tooltip button control that shows tooltip above on hover
/// </summary>
public sealed class QuietCougar91 : ContentControl
{
    /// <summary>
    /// 툴팁에 표시될 내용
    /// Content to be displayed in the tooltip
    /// </summary>
    public static readonly DependencyProperty TooltipContentProperty =
        DependencyProperty.Register(
            nameof(TooltipContent),
            typeof(object),
            typeof(QuietCougar91),
            new PropertyMetadata("Uiverse.io"));

    /// <summary>
    /// 버튼에 표시될 텍스트
    /// Text to be displayed on the button
    /// </summary>
    public static readonly DependencyProperty ButtonTextProperty =
        DependencyProperty.Register(
            nameof(ButtonText),
            typeof(string),
            typeof(QuietCougar91),
            new PropertyMetadata("Hover me"));

    static QuietCougar91()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(QuietCougar91),
            new FrameworkPropertyMetadata(typeof(QuietCougar91)));
    }

    public object TooltipContent
    {
        get => GetValue(TooltipContentProperty);
        set => SetValue(TooltipContentProperty, value);
    }

    public string ButtonText
    {
        get => (string)GetValue(ButtonTextProperty);
        set => SetValue(ButtonTextProperty, value);
    }
}

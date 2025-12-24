using System.Windows;
using System.Windows.Controls;

namespace UglyPug52.Wpf.UI.Controls;

/// <summary>
/// Tooltip이 있는 장바구니 버튼 컨트롤.
/// 호버 시 텍스트가 아이콘으로 전환되고 툴팁이 표시됩니다.
/// </summary>
public sealed class UglyPug52 : Button
{
    /// <summary>
    /// 툴팁에 표시될 텍스트를 가져오거나 설정합니다.
    /// </summary>
    public static readonly DependencyProperty TooltipTextProperty =
        DependencyProperty.Register(
            nameof(TooltipText),
            typeof(string),
            typeof(UglyPug52),
            new PropertyMetadata("PRICE $20"));

    public string TooltipText
    {
        get => (string)GetValue(TooltipTextProperty);
        set => SetValue(TooltipTextProperty, value);
    }

    static UglyPug52()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(UglyPug52),
            new FrameworkPropertyMetadata(typeof(UglyPug52)));
    }
}

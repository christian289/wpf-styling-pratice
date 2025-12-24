using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace UglyPug52.Avalonia.Lib.Controls;

/// <summary>
/// Add To Cart 버튼 컨트롤 - 호버 시 텍스트가 위로 슬라이드되고 아이콘이 나타나며, 툴팁이 표시됨
/// Add To Cart button control - On hover, text slides up, icon appears, and tooltip is displayed
/// </summary>
public sealed class UglyPug52Button : TemplatedControl
{
    /// <summary>
    /// 버튼 텍스트
    /// Button text
    /// </summary>
    public static readonly StyledProperty<string> TextProperty =
        AvaloniaProperty.Register<UglyPug52Button, string>(nameof(Text), "Add To Cart");

    /// <summary>
    /// 툴팁 텍스트
    /// Tooltip text
    /// </summary>
    public static readonly StyledProperty<string> TooltipTextProperty =
        AvaloniaProperty.Register<UglyPug52Button, string>(nameof(TooltipText), "PRICE $20");

    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public string TooltipText
    {
        get => GetValue(TooltipTextProperty);
        set => SetValue(TooltipTextProperty, value);
    }
}

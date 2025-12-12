using Avalonia;
using Avalonia.Controls.Primitives;

namespace GiantCatfish51.Avalonia.Lib.Controls;

/// <summary>
/// 호버 시 상단에 툴팁이 나타나는 버튼 컨트롤
/// A button control that displays a tooltip above when hovered
/// </summary>
public sealed class TooltipButton : TemplatedControl
{
    public static readonly StyledProperty<string> TextProperty =
        AvaloniaProperty.Register<TooltipButton, string>(nameof(Text), "Button");

    public static readonly StyledProperty<string> TooltipTextProperty =
        AvaloniaProperty.Register<TooltipButton, string>(nameof(TooltipText), "Tooltip");

    /// <summary>
    /// 버튼에 표시되는 텍스트
    /// Text displayed on the button
    /// </summary>
    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    /// <summary>
    /// 툴팁에 표시되는 텍스트
    /// Text displayed in the tooltip
    /// </summary>
    public string TooltipText
    {
        get => GetValue(TooltipTextProperty);
        set => SetValue(TooltipTextProperty, value);
    }
}

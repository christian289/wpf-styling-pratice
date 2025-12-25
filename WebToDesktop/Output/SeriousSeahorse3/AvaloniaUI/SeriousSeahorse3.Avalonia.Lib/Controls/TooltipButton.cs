using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace SeriousSeahorse3.Avalonia.Lib.Controls;

/// <summary>
/// 상단에 툴팁을 표시하는 버튼 컨트롤.
/// A button control that displays a tooltip above it.
/// </summary>
public sealed class TooltipButton : TemplatedControl
{
    /// <summary>
    /// 툴팁 텍스트를 정의하는 속성.
    /// Property that defines the tooltip text.
    /// </summary>
    public static readonly StyledProperty<string> TooltipTextProperty =
        AvaloniaProperty.Register<TooltipButton, string>(nameof(TooltipText), "Tooltip");

    /// <summary>
    /// 버튼 내용을 정의하는 속성.
    /// Property that defines the button content.
    /// </summary>
    public static readonly StyledProperty<object?> ContentProperty =
        AvaloniaProperty.Register<TooltipButton, object?>(nameof(Content), "Click me");

    /// <summary>
    /// 툴팁에 표시될 텍스트.
    /// Text to be displayed in the tooltip.
    /// </summary>
    public string TooltipText
    {
        get => GetValue(TooltipTextProperty);
        set => SetValue(TooltipTextProperty, value);
    }

    /// <summary>
    /// 버튼에 표시될 내용.
    /// Content to be displayed in the button.
    /// </summary>
    public object? Content
    {
        get => GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }
}

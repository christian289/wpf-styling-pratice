using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace BitterSkunk14.Avalonia.Lib.Controls;

/// <summary>
/// 호버 시 툴팁이 애니메이션과 함께 나타나는 버튼 컨트롤.
/// A button control that shows a tooltip with animation on hover.
/// </summary>
public sealed class BitterSkunk14TooltipButton : TemplatedControl
{
    /// <summary>
    /// 버튼에 표시할 텍스트.
    /// Text to display on the button.
    /// </summary>
    public static readonly StyledProperty<string> TextProperty =
        AvaloniaProperty.Register<BitterSkunk14TooltipButton, string>(nameof(Text), "Tooltip");

    /// <summary>
    /// 툴팁에 표시할 메시지.
    /// Message to display in the tooltip.
    /// </summary>
    public static readonly StyledProperty<string> TooltipMessageProperty =
        AvaloniaProperty.Register<BitterSkunk14TooltipButton, string>(nameof(TooltipMessage), "This is a test");

    /// <summary>
    /// 툴팁 내 버튼에 표시할 텍스트.
    /// Text to display on the button inside the tooltip.
    /// </summary>
    public static readonly StyledProperty<string> TooltipButtonTextProperty =
        AvaloniaProperty.Register<BitterSkunk14TooltipButton, string>(nameof(TooltipButtonText), "Got It");

    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public string TooltipMessage
    {
        get => GetValue(TooltipMessageProperty);
        set => SetValue(TooltipMessageProperty, value);
    }

    public string TooltipButtonText
    {
        get => GetValue(TooltipButtonTextProperty);
        set => SetValue(TooltipButtonTextProperty, value);
    }
}

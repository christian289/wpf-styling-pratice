using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace BitterWolverine27.Avalonia.Lib.Controls;

/// <summary>
/// 호버 시 팝업 애니메이션과 함께 툴팁이 나타나는 커스텀 컨트롤
/// A custom control that displays a tooltip with popup animation on hover
/// </summary>
public sealed class HoverTooltip : TemplatedControl
{
    /// <summary>
    /// 트리거 텍스트를 정의하는 Styled Property
    /// Styled Property that defines the trigger text
    /// </summary>
    public static readonly StyledProperty<string> TriggerTextProperty =
        AvaloniaProperty.Register<HoverTooltip, string>(nameof(TriggerText), "Hover me !");

    /// <summary>
    /// 툴팁 텍스트를 정의하는 Styled Property
    /// Styled Property that defines the tooltip text
    /// </summary>
    public static readonly StyledProperty<string> TooltipTextProperty =
        AvaloniaProperty.Register<HoverTooltip, string>(nameof(TooltipText), "Heyy👋");

    /// <summary>
    /// 트리거 텍스트
    /// The trigger text displayed in the control
    /// </summary>
    public string TriggerText
    {
        get => GetValue(TriggerTextProperty);
        set => SetValue(TriggerTextProperty, value);
    }

    /// <summary>
    /// 툴팁 텍스트
    /// The tooltip text displayed when hovering
    /// </summary>
    public string TooltipText
    {
        get => GetValue(TooltipTextProperty);
        set => SetValue(TooltipTextProperty, value);
    }
}

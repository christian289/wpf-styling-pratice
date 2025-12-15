using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace QuietCougar91.Avalonia.Lib.Controls;

/// <summary>
/// 호버 시 텍스트가 위로 이동하고 툴팁이 나타나는 버튼 컨트롤.
/// A button control with hover text animation and tooltip display.
/// </summary>
public sealed class QuietCougar91Button : TemplatedControl
{
    public static readonly StyledProperty<string> TextProperty =
        AvaloniaProperty.Register<QuietCougar91Button, string>(nameof(Text), "Hover me");

    public static readonly StyledProperty<string> TooltipTextProperty =
        AvaloniaProperty.Register<QuietCougar91Button, string>(nameof(TooltipText), "Uiverse.io");

    public static readonly StyledProperty<object?> TooltipIconProperty =
        AvaloniaProperty.Register<QuietCougar91Button, object?>(nameof(TooltipIcon));

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

    public object? TooltipIcon
    {
        get => GetValue(TooltipIconProperty);
        set => SetValue(TooltipIconProperty, value);
    }
}

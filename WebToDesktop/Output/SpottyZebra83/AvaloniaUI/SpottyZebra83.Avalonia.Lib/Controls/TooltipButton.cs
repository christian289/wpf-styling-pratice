using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace SpottyZebra83.Avalonia.Lib.Controls;

public sealed class TooltipButton : TemplatedControl
{
    public static readonly StyledProperty<string> TextProperty =
        AvaloniaProperty.Register<TooltipButton, string>(nameof(Text), "Tooltip");

    public static readonly StyledProperty<string> TooltipTextProperty =
        AvaloniaProperty.Register<TooltipButton, string>(nameof(TooltipText), "Uiverse.io");

    public static readonly StyledProperty<string> HoverTextProperty =
        AvaloniaProperty.Register<TooltipButton, string>(nameof(HoverText), "Hello!");

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

    public string HoverText
    {
        get => GetValue(HoverTextProperty);
        set => SetValue(HoverTextProperty, value);
    }
}

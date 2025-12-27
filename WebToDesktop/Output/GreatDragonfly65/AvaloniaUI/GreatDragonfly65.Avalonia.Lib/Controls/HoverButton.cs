using Avalonia;
using Avalonia.Controls.Primitives;

namespace GreatDragonfly65.Avalonia.Lib.Controls;

/// <summary>
/// 복잡한 클리핑 애니메이션이 있는 호버 버튼 컨트롤
/// Hover button control with complex clipping animations
/// </summary>
public sealed class HoverButton : TemplatedControl
{
    public static readonly StyledProperty<string> TextProperty =
        AvaloniaProperty.Register<HoverButton, string>(nameof(Text), "Hover Me");

    public static readonly StyledProperty<string> HoverTextProperty =
        AvaloniaProperty.Register<HoverButton, string>(nameof(HoverText), "SMOOKY DEV");

    public static readonly StyledProperty<string> BeforeTextProperty =
        AvaloniaProperty.Register<HoverButton, string>(nameof(BeforeText), "Hover ME");

    public static readonly StyledProperty<string> BeforeHoverTextProperty =
        AvaloniaProperty.Register<HoverButton, string>(nameof(BeforeHoverText), "SMOOKY");

    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public string HoverText
    {
        get => GetValue(HoverTextProperty);
        set => SetValue(HoverTextProperty, value);
    }

    public string BeforeText
    {
        get => GetValue(BeforeTextProperty);
        set => SetValue(BeforeTextProperty, value);
    }

    public string BeforeHoverText
    {
        get => GetValue(BeforeHoverTextProperty);
        set => SetValue(BeforeHoverTextProperty, value);
    }
}

using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace WetQuail86.Avalonia.Lib.Controls;

/// <summary>
/// Hover 시 타이틀이 툴팁처럼 나타나는 커스텀 TextBox 컨트롤
/// A custom TextBox control where the title appears like a tooltip on hover
/// </summary>
public sealed class WetQuail86TextBox : TemplatedControl
{
    public static readonly StyledProperty<string> TitleProperty =
        AvaloniaProperty.Register<WetQuail86TextBox, string>(nameof(Title), "Title");

    public static readonly StyledProperty<string> TextProperty =
        AvaloniaProperty.Register<WetQuail86TextBox, string>(nameof(Text), string.Empty);

    public static readonly StyledProperty<string> PlaceholderProperty =
        AvaloniaProperty.Register<WetQuail86TextBox, string>(nameof(Placeholder), string.Empty);

    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public string Placeholder
    {
        get => GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }
}

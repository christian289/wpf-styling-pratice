using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace SourOtter25.Avalonia.Lib.Controls;

/// <summary>
/// CSS clip-path polygon 효과와 hover 애니메이션을 제공하는 카드 컨트롤.
/// A card control that provides CSS clip-path polygon effect with hover animations.
/// </summary>
public sealed class ClipPathCard : TemplatedControl
{
    public static readonly StyledProperty<string> TitleProperty =
        AvaloniaProperty.Register<ClipPathCard, string>(nameof(Title), "CSS Clip-Path");

    public static readonly StyledProperty<string> SubtitleProperty =
        AvaloniaProperty.Register<ClipPathCard, string>(nameof(Subtitle), "ELEKTRO RAKS");

    public static readonly StyledProperty<string> DescriptionProperty =
        AvaloniaProperty.Register<ClipPathCard, string>(nameof(Description), "Custom card");

    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string Subtitle
    {
        get => GetValue(SubtitleProperty);
        set => SetValue(SubtitleProperty, value);
    }

    public string Description
    {
        get => GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }
}

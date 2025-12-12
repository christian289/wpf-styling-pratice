using Avalonia;
using Avalonia.Controls.Primitives;

namespace TinyMayfly20.Avalonia.Lib.Controls;

/// <summary>
/// Goku 픽셀 아트가 있는 알림 컨트롤.
/// Goku pixel art notification control.
/// </summary>
public sealed class TinyMayfly20 : TemplatedControl
{
    public static readonly StyledProperty<string> TitleProperty =
        AvaloniaProperty.Register<TinyMayfly20, string>(nameof(Title), "Level up!");

    public static readonly StyledProperty<string> SubtitleProperty =
        AvaloniaProperty.Register<TinyMayfly20, string>(nameof(Subtitle), "Your power:");

    public static readonly StyledProperty<string> PowerTextProperty =
        AvaloniaProperty.Register<TinyMayfly20, string>(nameof(PowerText), "+8000!");

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

    public string PowerText
    {
        get => GetValue(PowerTextProperty);
        set => SetValue(PowerTextProperty, value);
    }
}

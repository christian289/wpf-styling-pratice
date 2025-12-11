using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace SillyGrasshopper43.Avalonia.Lib.Controls;

/// <summary>
/// 두 개의 원이 교차하며 회전하는 로더 애니메이션 컨트롤
/// A loader animation control with two circles crossing each other
/// </summary>
public sealed class Loader : ContentControl
{
    static Loader()
    {
        AffectsRender<Loader>(
            ForegroundColorProperty,
            BackgroundColorProperty);
    }

    /// <summary>
    /// 첫 번째 원의 색상 (기본값: #fc3f9e)
    /// First circle color (default: #fc3f9e)
    /// </summary>
    public static readonly StyledProperty<Color> ForegroundColorProperty =
        AvaloniaProperty.Register<Loader, Color>(
            nameof(ForegroundColor),
            Color.Parse("#fc3f9e"));

    public Color ForegroundColor
    {
        get => GetValue(ForegroundColorProperty);
        set => SetValue(ForegroundColorProperty, value);
    }

    /// <summary>
    /// 두 번째 원의 색상 (기본값: #50e8f3)
    /// Second circle color (default: #50e8f3)
    /// </summary>
    public static readonly StyledProperty<Color> BackgroundColorProperty =
        AvaloniaProperty.Register<Loader, Color>(
            nameof(BackgroundColor),
            Color.Parse("#50e8f3"));

    public Color BackgroundColor
    {
        get => GetValue(BackgroundColorProperty);
        set => SetValue(BackgroundColorProperty, value);
    }
}

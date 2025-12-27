using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Media;

namespace BitterMoth36.Avalonia.Lib.Controls;

/// <summary>
/// 회전하면서 두 개의 원이 스케일 애니메이션을 하는 로더 컨트롤
/// A loader control with two circles that scale while rotating
/// </summary>
public sealed class BitterMoth36Loader : TemplatedControl
{
    static BitterMoth36Loader()
    {
        AffectsRender<BitterMoth36Loader>(
            TopCircleColorProperty,
            BottomCircleColorProperty);
    }

    /// <summary>
    /// 상단 원의 색상
    /// Top circle color
    /// </summary>
    public static readonly StyledProperty<IBrush?> TopCircleColorProperty =
        AvaloniaProperty.Register<BitterMoth36Loader, IBrush?>(
            nameof(TopCircleColor));

    public IBrush? TopCircleColor
    {
        get => GetValue(TopCircleColorProperty);
        set => SetValue(TopCircleColorProperty, value);
    }

    /// <summary>
    /// 하단 원의 색상
    /// Bottom circle color
    /// </summary>
    public static readonly StyledProperty<IBrush?> BottomCircleColorProperty =
        AvaloniaProperty.Register<BitterMoth36Loader, IBrush?>(
            nameof(BottomCircleColor));

    public IBrush? BottomCircleColor
    {
        get => GetValue(BottomCircleColorProperty);
        set => SetValue(BottomCircleColorProperty, value);
    }
}

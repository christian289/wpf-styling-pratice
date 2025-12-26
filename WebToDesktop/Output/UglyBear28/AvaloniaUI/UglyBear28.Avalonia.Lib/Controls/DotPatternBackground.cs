using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace UglyBear28.Avalonia.Lib.Controls;

/// <summary>
/// CSS contrast filter + radial gradient dot pattern을 AvaloniaUI로 구현한 배경 컨트롤
/// 원본: radial-gradient(#000, transparent) 0 0/1em 1em space with mask
/// CSS contrast filter with radial gradient dot pattern background control for AvaloniaUI
/// </summary>
public sealed class DotPatternBackground : ContentControl
{
    public static readonly StyledProperty<IBrush?> BackgroundColorProperty =
        AvaloniaProperty.Register<DotPatternBackground, IBrush?>(
            nameof(BackgroundColor),
            new SolidColorBrush(Colors.White));

    public static readonly StyledProperty<IBrush?> DotColorProperty =
        AvaloniaProperty.Register<DotPatternBackground, IBrush?>(
            nameof(DotColor),
            new SolidColorBrush(Colors.Black));

    public static readonly StyledProperty<double> DotSizeProperty =
        AvaloniaProperty.Register<DotPatternBackground, double>(
            nameof(DotSize),
            12.0);

    public static readonly StyledProperty<double> DotSpacingProperty =
        AvaloniaProperty.Register<DotPatternBackground, double>(
            nameof(DotSpacing),
            16.0);

    public static readonly StyledProperty<double> DotOpacityProperty =
        AvaloniaProperty.Register<DotPatternBackground, double>(
            nameof(DotOpacity),
            0.45);

    /// <summary>
    /// 배경색
    /// Background color
    /// </summary>
    public IBrush? BackgroundColor
    {
        get => GetValue(BackgroundColorProperty);
        set => SetValue(BackgroundColorProperty, value);
    }

    /// <summary>
    /// 도트 색상
    /// Dot color
    /// </summary>
    public IBrush? DotColor
    {
        get => GetValue(DotColorProperty);
        set => SetValue(DotColorProperty, value);
    }

    /// <summary>
    /// 도트 크기 (픽셀)
    /// Dot size in pixels
    /// </summary>
    public double DotSize
    {
        get => GetValue(DotSizeProperty);
        set => SetValue(DotSizeProperty, value);
    }

    /// <summary>
    /// 도트 간격 (픽셀)
    /// Dot spacing in pixels
    /// </summary>
    public double DotSpacing
    {
        get => GetValue(DotSpacingProperty);
        set => SetValue(DotSpacingProperty, value);
    }

    /// <summary>
    /// 도트 불투명도 (0~1)
    /// Dot opacity (0~1)
    /// </summary>
    public double DotOpacity
    {
        get => GetValue(DotOpacityProperty);
        set => SetValue(DotOpacityProperty, value);
    }
}

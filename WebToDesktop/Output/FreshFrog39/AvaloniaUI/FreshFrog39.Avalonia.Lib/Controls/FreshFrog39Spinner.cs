using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;

namespace FreshFrog39.Avalonia.Lib.Controls;

/// <summary>
/// 3개의 원이 순차적으로 페이드 애니메이션을 실행하는 스피너 컨트롤
/// A spinner control with 3 circles that fade in sequence
/// </summary>
public sealed class FreshFrog39Spinner : TemplatedControl
{
    /// <summary>
    /// 스피너 원의 색상을 정의합니다.
    /// Defines the color of the spinner circles.
    /// </summary>
    public static readonly StyledProperty<IBrush> SpinnerColorProperty =
        AvaloniaProperty.Register<FreshFrog39Spinner, IBrush>(
            nameof(SpinnerColor),
            new SolidColorBrush(Color.FromRgb(0, 113, 128)));

    /// <summary>
    /// 원 사이의 간격을 정의합니다.
    /// Defines the gap between circles.
    /// </summary>
    public static readonly StyledProperty<double> GapProperty =
        AvaloniaProperty.Register<FreshFrog39Spinner, double>(
            nameof(Gap),
            6.0);

    /// <summary>
    /// 각 원의 크기를 정의합니다.
    /// Defines the size of each circle.
    /// </summary>
    public static readonly StyledProperty<double> CircleSizeProperty =
        AvaloniaProperty.Register<FreshFrog39Spinner, double>(
            nameof(CircleSize),
            20.0);

    /// <summary>
    /// 스피너 원의 색상
    /// The color of the spinner circles
    /// </summary>
    public IBrush SpinnerColor
    {
        get => GetValue(SpinnerColorProperty);
        set => SetValue(SpinnerColorProperty, value);
    }

    /// <summary>
    /// 원 사이의 간격 (픽셀)
    /// The gap between circles (in pixels)
    /// </summary>
    public double Gap
    {
        get => GetValue(GapProperty);
        set => SetValue(GapProperty, value);
    }

    /// <summary>
    /// 각 원의 크기 (픽셀)
    /// The size of each circle (in pixels)
    /// </summary>
    public double CircleSize
    {
        get => GetValue(CircleSizeProperty);
        set => SetValue(CircleSizeProperty, value);
    }
}

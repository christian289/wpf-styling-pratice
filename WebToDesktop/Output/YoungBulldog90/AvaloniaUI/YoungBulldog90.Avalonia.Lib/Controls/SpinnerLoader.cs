using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Media;

namespace YoungBulldog90.Avalonia.Lib.Controls;

/// <summary>
/// 회전하는 스피너 로더 컨트롤
/// A rotating spinner loader control
/// </summary>
public sealed class SpinnerLoader : TemplatedControl
{
    /// <summary>
    /// 스피너 색상 속성
    /// Spinner color property
    /// </summary>
    public static readonly StyledProperty<IBrush?> SpinnerBrushProperty =
        AvaloniaProperty.Register<SpinnerLoader, IBrush?>(
            nameof(SpinnerBrush),
            Brushes.Purple);

    /// <summary>
    /// 스피너 두께 속성
    /// Spinner thickness property
    /// </summary>
    public static readonly StyledProperty<double> SpinnerThicknessProperty =
        AvaloniaProperty.Register<SpinnerLoader, double>(
            nameof(SpinnerThickness),
            2.0);

    /// <summary>
    /// 스피너 색상
    /// Spinner color
    /// </summary>
    public IBrush? SpinnerBrush
    {
        get => GetValue(SpinnerBrushProperty);
        set => SetValue(SpinnerBrushProperty, value);
    }

    /// <summary>
    /// 스피너 두께
    /// Spinner thickness
    /// </summary>
    public double SpinnerThickness
    {
        get => GetValue(SpinnerThicknessProperty);
        set => SetValue(SpinnerThicknessProperty, value);
    }
}
